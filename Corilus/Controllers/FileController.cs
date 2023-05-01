using AutoMapper;
using Corilus.Data;
using Corilus.Models;
using Corilus.Models.DTO;
using Corilus.Repository.IRepository;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection.PortableExecutable;

namespace Corilus.Controllers
{
    [Route("api/FileAPI")]
    [ApiController]
    public class FileController:ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileRepository _dbFile;

        private readonly IMapper _mapper;

        protected APIResponse _response;
        public FileController(ApplicationDbContext db, IMapper mapper, IFileRepository dbFile)
        {
            _db = db;
            _mapper = mapper;
            _dbFile = dbFile;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetFiles()
        {
             

            IEnumerable<ErrorFile> fileList = await _dbFile.GetAllAsync();
            _response.Result = _mapper.Map<List<FileDTO>>(fileList);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpGet("{id:int}", Name = "GetFile")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetFile(int id)
        {
            try
            {
                if (id == 0)
                {
                    //_logger.Log("get villa error!" + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var errorFile = await _dbFile.GetAsync(x => x.Id == id);

                if (errorFile == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<FileDTO>(errorFile);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpDelete("{id:int}", Name = "DeleteFile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteFile(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbFile.GetAsync(x => x.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbFile.RemoveAsync(villa);
                await _dbFile.Save();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> CreateFile([FromForm]/[FromBody]IFormFile file)
        
            public async Task<ActionResult<APIResponse>> CreateFile(/*[FromForm]*/ IFormFile file)
        {
            try
            {
                var contenu = new StreamReader(file.OpenReadStream()).ReadToEnd();
                
                    Guid g = Guid.NewGuid();
                var copyfileName = DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + '-' + g + Path.GetExtension(file.FileName);
                var filePath = Path.Combine("D:/Uploads/", copyfileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);



                }
                var model = new FileCreateDTO
                {
                    Name = file.FileName,
                    Size = (int)file.Length,
                    Content = contenu,
                    Description = file.ContentType,
                    Records = {},
                    
                };
                
                if (await _dbFile.GetAsync(u => u.Name.ToLower() == model.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "File already exist!");
                    return BadRequest(ModelState);
                }
                
              

                if (model == null)
                {
                    return BadRequest();
                }
              


                if (file.Length > 0) { model.Name = copyfileName;
                   var stream = new StreamReader(file.OpenReadStream());
                    
                        char[] buffer = new char[7];
                        await stream.ReadBlockAsync(buffer, 0, 6);
                        string result = new string(buffer);

                        switch (result)
                        {
                            case "920000":
                                model.Description = "Fichier de Facturation: Reception";
                                break;
                            case "920999":
                                model.Description = "Refus de Fichier";
                                break;
                            case "931000":
                                model.Description = "Acceptation de fichier";
                                break;
                            case "920099":
                                model.Description = "Refus d'envoi aprés bloquer les erreurs détectés";
                                break;
                            case "920098":
                                model.Description = "Taux d'erreur acceptable: Acceptation message";
                                break;
                            case "920500":
                                model.Description = "Fichier de décompte";
                                break;

                        }
                    

                    }
                if (file.Length > 0)
                {
                    var stream = new StreamReader(file.OpenReadStream());
                    char[] buffer = new char[228];
                    char[] buffer1 = new char[228];
                    char[] buffer2 = new char[350];
                    char[] buffer3 = new char[350];
                    await stream.ReadBlockAsync(buffer, 0, 228);
                    string s = new string(buffer);
                   
                    //string text = new string(stream);
                    string seg200 = s.Substring(0, 66);
                    string seg300 = s.Substring(67,227);
                    string body = s.Substring(228, (int)file.Length- 701);
                    int l=(int)body.Length;
                    string footer = s.Substring((int)file.Length - 700, (int)file.Length);
                    String[] recordsContenu = {seg200,seg300,body,footer};
                    
                 
                   
                    var model1 = new RecordCreateDTO
                    {

                        Size = 0,
                        Content = "contenu",
                        Type = "Type record",

                    };
                    foreach ( string i in recordsContenu){
                        switch (i.Length)
                        {
                            case 67:
                                
                                model1.Type = "Record200";
                                model1.Content =i;
                                model1.Size = 67;
                                break;
                            case 160:
                                model1.Type = "Record300";
                                model1.Content = i;
                                model1.Size = 160;
                                break;
                            case 700:
                                model1.Type = "footer";
                                model1.Content = i;
                                model1.Size = 700;
                                break;
                            default:
                                model1.Type = "body";
                                model1.Content = i;
                                model1.Size = l;
                                break;

                        }

                        model.Records.Append<RecordCreateDTO>(model1);

                    }
                   
                  
                    
                    


                    

                }

                ErrorFile filetodb = _mapper.Map<ErrorFile>(model);
                await _dbFile.CreateAsync(filetodb);
                _response.Result = _mapper.Map<FileDTO>(filetodb);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetFile", new { id = filetodb.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
      

    }

}

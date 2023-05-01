using AutoMapper;
using Corilus.Models;
using Corilus.Models.DTO;

namespace Corilus
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ErrorFile, FileDTO>().ReverseMap();
            CreateMap<ErrorFile, FileCreateDTO>().ReverseMap();
            CreateMap<RecordModel, RecordDTO>().ReverseMap();
            CreateMap<RecordModel, RecordCreateDTO>().ReverseMap();



        }
    }
}
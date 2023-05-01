using System.ComponentModel.DataAnnotations;

namespace Corilus.Models.DTO
{
    public class FileCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Size { get; set; }

        public IEnumerable<RecordCreateDTO> Records { get; set; }

    }
}

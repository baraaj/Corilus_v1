using System.ComponentModel.DataAnnotations;

namespace Corilus.Models.DTO
{
    public class FileDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public float Size { get; set; }

        public IEnumerable<RecordDTO> Records { get; set; }
    }
}

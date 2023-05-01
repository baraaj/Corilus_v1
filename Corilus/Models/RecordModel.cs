using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corilus.Models
{
    public class RecordModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Content { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }
    }
}

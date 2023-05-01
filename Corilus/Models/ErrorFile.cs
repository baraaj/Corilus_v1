using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corilus.Models
{
    public class ErrorFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
      
        public int Size { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }

        public IEnumerable<RecordModel> Records { get; set; }
    }
    

}

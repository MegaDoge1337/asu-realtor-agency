using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtors.Entities
{
    [Table("Districts")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtors.Entities
{
    [Table("EvaluationCriteria")]
    public class EvaluationCriteria
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

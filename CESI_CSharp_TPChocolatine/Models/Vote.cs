using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class Vote
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ExpressionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class VoteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public ExpressionViewModel Expression { get; set; }
    }
}

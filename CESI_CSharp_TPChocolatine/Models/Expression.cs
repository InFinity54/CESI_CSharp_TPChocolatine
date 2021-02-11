using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class Expression
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Original { get; set; }

        [Required]
        public string Regional { get; set; }
        
        [Required]
        [Display(Name = "User")]

        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "Region")]

        public int RegionId { get; set; }
    }
}

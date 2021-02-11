using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }
    }
}

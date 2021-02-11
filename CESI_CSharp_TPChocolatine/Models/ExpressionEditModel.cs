using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class ExpressionEditModel
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

        public IDictionary<int, string> AllUsers { get; set; }

        [Required]
        [Display(Name = "Region")]

        public int RegionId { get; set; }

        public IDictionary<int, string> AllRegions { get; set; }
    }
}

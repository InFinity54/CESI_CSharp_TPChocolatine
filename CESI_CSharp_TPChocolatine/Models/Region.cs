using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class Region
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

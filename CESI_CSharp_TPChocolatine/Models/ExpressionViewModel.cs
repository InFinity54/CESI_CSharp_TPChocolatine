using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class ExpressionViewModel
    {
        public int Id { get; set; }

        public string Original { get; set; }

        public string Regional { get; set; }

        public User User { get; set; }

        public Region Region { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class VoteEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public IDictionary<int, string> AllUsers { get; set; }

        [Required]
        public int ExpressionId { get; set; }

        public IDictionary<int, string> AllExpressions { get; set; }
    }
}

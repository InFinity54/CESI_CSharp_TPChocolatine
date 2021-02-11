using System.Collections.Generic;

namespace CESI_CSharp_TPChocolatine.Models
{
    public class UserEditModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RegionId { get; set; }

        public IDictionary<int, string> AllRegions { get; set; }
    }
}

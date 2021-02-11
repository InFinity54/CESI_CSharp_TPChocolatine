using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Data;
using CESI_CSharp_TPChocolatine.Models;

namespace CESI_CSharp_TPChocolatine.Views.Regions
{
    public class IndexModel : PageModel
    {
        private readonly DefaultContext _context;

        public IndexModel(DefaultContext context)
        {
            _context = context;
        }

        public IList<Region> Region { get;set; }

        public async Task OnGetAsync()
        {
            Region = await _context.Region.ToListAsync();
        }
    }
}

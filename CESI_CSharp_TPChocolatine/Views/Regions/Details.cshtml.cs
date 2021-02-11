using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Data;
using CESI_CSharp_TPChocolatine.Models;

namespace CESI_CSharp_TPChocolatine.Views.Regions
{
    public class DetailsModel : PageModel
    {
        private readonly DefaultContext _context;

        public DetailsModel(DefaultContext context)
        {
            _context = context;
        }

        public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Region = await _context.Region.FirstOrDefaultAsync(m => m.Id == id);

            if (Region == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Data;
using CESI_CSharp_TPChocolatine.Models;
using System.Collections.Generic;

namespace CESI_CSharp_TPChocolatine.Controllers
{
    public class ExpressionsController : Controller
    {
        private readonly DefaultContext _context;

        public ExpressionsController(DefaultContext context)
        {
            _context = context;
        }

        // GET: Expressions
        public async Task<IActionResult> Index()
        {
            List<Expression> expressions = _context.Expression.OrderBy(m => m.Original).ToList();
            List<ExpressionViewModel> displayedExpressions = new List<ExpressionViewModel>();

            foreach (Expression expression in expressions)
            {
                ExpressionViewModel displayExpression = new ExpressionViewModel();
                displayExpression.Id = expression.Id;
                displayExpression.Original = expression.Original;
                displayExpression.Regional = expression.Regional;
                displayExpression.User = _context.User.Find(expression.UserId);
                displayExpression.Region = _context.Region.Find(expression.RegionId);

                displayedExpressions.Add(displayExpression);
            }

            return View(displayedExpressions);
        }

        // GET: Expressions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expression = await _context.Expression
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expression == null)
            {
                return NotFound();
            }

            ExpressionViewModel displayExpression = new ExpressionViewModel();
            displayExpression.Id = expression.Id;
            displayExpression.Original = expression.Original;
            displayExpression.Regional = expression.Regional;
            displayExpression.User = _context.User.Find(expression.UserId);
            displayExpression.Region = _context.Region.Find(expression.RegionId);

            return View(displayExpression);
        }

        // GET: Expressions/Create
        public IActionResult Create()
        {
            var vm = new ExpressionEditModel
            {
                AllUsers = _context.User.OrderBy(m => m.LastName).ThenBy(m => m.FirstName).ToDictionary(x => x.Id, x => $"{ x.LastName } { x.FirstName }"),
                AllRegions = _context.Region.OrderBy(m => m.Name).ToDictionary(x => x.Id, x => $"{ x.Name }")
            };
            return View(vm);
        }

        // POST: Expressions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Original,Regional,UserId,RegionId")] Expression expression)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expression);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expression);
        }

        // GET: Expressions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expression = await _context.Expression
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expression == null)
            {
                return NotFound();
            }

            ExpressionViewModel displayExpression = new ExpressionViewModel();
            displayExpression.Id = expression.Id;
            displayExpression.Original = expression.Original;
            displayExpression.Regional = expression.Regional;
            displayExpression.User = _context.User.Find(expression.UserId);
            displayExpression.Region = _context.Region.Find(expression.RegionId);

            return View(displayExpression);
        }

        // POST: Expressions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expression = await _context.Expression.FindAsync(id);
            _context.Expression.Remove(expression);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpressionExists(int id)
        {
            return _context.Expression.Any(e => e.Id == id);
        }
    }
}

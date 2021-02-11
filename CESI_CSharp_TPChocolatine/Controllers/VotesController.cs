using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Data;
using CESI_CSharp_TPChocolatine.Models;
using System.Collections.Generic;

namespace CESI_CSharp_TPChocolatine.Controllers
{
    public class VotesController : Controller
    {
        private readonly DefaultContext _context;

        public VotesController(DefaultContext context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {
            List<Vote> votes = _context.Vote.OrderByDescending(m => m.Id).ToList();
            List<VoteViewModel> displayedVotes = new List<VoteViewModel>();

            foreach (Vote vote in votes)
            {
                Expression expression = _context.Expression.Find(vote.ExpressionId);

                ExpressionViewModel viewExpression = new ExpressionViewModel();
                viewExpression.Id = expression.Id;
                viewExpression.Original = expression.Original;
                viewExpression.Regional = expression.Regional;
                viewExpression.User = _context.User.Find(expression.UserId);
                viewExpression.Region = _context.Region.Find(expression.RegionId);

                VoteViewModel displayVote = new VoteViewModel();
                displayVote.Id = vote.Id;
                displayVote.User = _context.User.Find(vote.UserId);
                displayVote.Expression = viewExpression;

                displayedVotes.Add(displayVote);
            }

            return View(displayedVotes);
        }

        // GET: Votes/Create
        public IActionResult Create()
        {
            List<Expression> expressions = _context.Expression.OrderBy(m => m.Original).ToList();
            Dictionary<int, string> formattedExpression = new Dictionary<int, string>();

            foreach (Expression expression in expressions)
            {
                Region expressionRegion = _context.Region.Find(expression.RegionId);
                formattedExpression.Add(expression.Id, expression.Original + " / " + expression.Regional + " (" + expressionRegion.Name + ")");
            }

            var vm = new VoteEditModel
            {
                AllUsers = _context.User.OrderBy(m => m.LastName).ThenBy(m => m.FirstName).ToDictionary(x => x.Id, x => $"{ x.LastName } { x.FirstName }"),
                AllExpressions = formattedExpression
            };
            return View(vm);
        }

        // POST: Votes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ExpressionId")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vote);
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.Id == id);
        }
    }
}

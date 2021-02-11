using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Data;
using CESI_CSharp_TPChocolatine.Models;
using System.Collections.Generic;

namespace CESI_CSharp_TPChocolatine.Controllers
{
    public class UsersController : Controller
    {
        private readonly DefaultContext _context;

        public UsersController(DefaultContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            List<User> users = _context.User.OrderBy(m => m.LastName).ThenBy(m => m.FirstName).ToList();
            List<UserViewModel> displayedUsers = new List<UserViewModel>();

            foreach (User user in users)
            {
                UserViewModel displayUser = new UserViewModel();
                displayUser.Id = user.Id;
                displayUser.LastName = user.LastName;
                displayUser.FirstName = user.FirstName;
                displayUser.Region = _context.Region.Find(user.RegionId);

                displayedUsers.Add(displayUser);
            }

            return View(displayedUsers);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            UserViewModel displayUser = new UserViewModel();
            displayUser.Id = user.Id;
            displayUser.LastName = user.LastName;
            displayUser.FirstName = user.FirstName;
            displayUser.Region = _context.Region.Find(user.RegionId);

            return View(displayUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var vm = new UserEditModel
            {
                AllRegions = _context.Region.OrderBy(m => m.Name).ToDictionary(x => x.Id, x => $"{ x.Name }")
            };
            return View(vm);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,RegionId")] UserEditModel user)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser.LastName = user.LastName;
                newUser.FirstName = user.FirstName;
                newUser.RegionId = user.RegionId;

                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var vm = new UserEditModel
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                RegionId = user.RegionId,
                AllRegions = _context.Region.ToDictionary(x => x.Id, x => $"{ x.Name }")
            };
            return View(vm);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,RegionId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            UserViewModel displayUser = new UserViewModel();
            displayUser.Id = user.Id;
            displayUser.LastName = user.LastName;
            displayUser.FirstName = user.FirstName;
            displayUser.Region = _context.Region.Find(user.RegionId);

            return View(displayUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}

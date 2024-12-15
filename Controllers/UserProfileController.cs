using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using System.Security.Claims;

namespace Projekt.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserProfileController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserProfile/Index
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles
                .Include(u => u.Użytkownik)
                .FirstOrDefaultAsync(u => u.Użytkownik.Id == userId);

            if (userProfile == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(userProfile);
        }

        // GET: UserProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                model.Użytkownik = user;
                _context.UserProfiles.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Dane zostały pomyślnie dodane!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: UserProfile/Edit
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles
                .Include(u => u.Użytkownik)
                .FirstOrDefaultAsync(u => u.Użytkownik.Id == userId);

            if (userProfile == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(userProfile);
        }

        // POST: UserProfile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserProfile model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles
                .Include(u => u.Użytkownik)
                .FirstOrDefaultAsync(u => u.Użytkownik.Id == userId);

            if (userProfile == null)
            {
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                userProfile.Imię = model.Imię;
                userProfile.Nazwisko = model.Nazwisko;
                userProfile.Adres = model.Adres;
                userProfile.KodPocztowy = model.KodPocztowy;
                userProfile.PhoneNumber = model.PhoneNumber;

                _context.UserProfiles.Update(userProfile);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Dane zostały pomyślnie zaktualizowane!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }
}

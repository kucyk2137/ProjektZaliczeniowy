using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using System.Security.Claims;

namespace Projekt.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product/Index
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await _context.product.Include(p => p.Użytkownik).Include(p => p.UserProfile).ToListAsync();
            return View(products);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Zdjęcie != null)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    Directory.CreateDirectory(uploadsFolder);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Zdjęcie.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Zdjęcie.CopyToAsync(fileStream);
                    }
                }

                var product = new Product
                {
                    Nazwa = model.Nazwa,
                    Opis = model.Opis,
                    Cena = model.Cena,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Użytkownik = await _context.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    ImagePath = uniqueFileName,
                };

                _context.product.Add(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Produkt został pomyślnie dodany!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.product.FindAsync(id);
            if (product == null || product.UserId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized();
            }

            return View(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var product = await _context.product.FindAsync(id);
                    if (product == null || product.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                    {
                        return Unauthorized();
                    }

                    string uniqueFileName = product.ImagePath;

                    // Usunięcie starego zdjęcia, jeśli nowe zostało przesłane
                    if (model.Zdjęcie != null)
                    {
                        if (!string.IsNullOrEmpty(product.ImagePath))
                        {
                            string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.ImagePath);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        Directory.CreateDirectory(uploadsFolder);
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Zdjęcie.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.Zdjęcie.CopyToAsync(fileStream);
                        }
                    }

                    product.Nazwa = model.Nazwa;
                    product.Opis = model.Opis;
                    product.Cena = model.Cena;
                    product.ImagePath = uniqueFileName;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.product.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(OwnIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null || product.UserId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized();
            }

            return View(product);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.product.FindAsync(id);
            if (product != null && product.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                // Usunięcie zdjęcia z serwera
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.ImagePath);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.product.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Unauthorized();
            }

            return RedirectToAction(nameof(OwnIndex));
        }
        [Authorize]
        public async Task<IActionResult> OwnIndex()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobierz ID zalogowanego użytkownika
            var userProducts = await _context.product
                .Where(p => p.UserId == userId)
                .ToListAsync(); // Filtruj produkty tylko dla zalogowanego użytkownika

            return View(userProducts);
        }
    }
}


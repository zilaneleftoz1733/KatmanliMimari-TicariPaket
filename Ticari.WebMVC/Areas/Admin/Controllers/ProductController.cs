using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using global::Ticari.Entities.DBContexts;
using global::Ticari.Entities.Entities.Concrete;

namespace Ticari.WebMVC.Areas.Admin.Controllers
{
   
        public class ProductController : Controller
        {
            private readonly SQLDbContext _context;

            public async Task<IActionResult> Index()
            {
                var products = await _context.Products.Include(p => p.Categories).ToListAsync();
                return View(products);
            }

 
            public IActionResult Create()
            {
                return View();
            }

          
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

      
            public async Task<IActionResult> Edit(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

       
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Product product)
            {
                if (id != product.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.Id))
                        {
                            return NotFound();
                        }
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

          
            public async Task<IActionResult> Delete(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

        
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ProductExists(int id)
            {
                return _context.Products.Any(e => e.Id == id);
            }
        }
    }



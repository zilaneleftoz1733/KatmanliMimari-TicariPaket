using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticari.Entities.DbContexts;
using Ticari.Entities.DBContexts;
using Ticari.Entities.TurkiyeDb;

namespace Ticari.WebMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly TurkiyeContext _context;

        public CityController(TurkiyeContext context)
        {
            _context = context;
        }

        // GET: City
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblIls.ToListAsync());
        }

        // GET: City/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIl = await _context.TblIls
                .FirstOrDefaultAsync(m => m.IlId == id);
            if (tblIl == null)
            {
                return NotFound();
            }

            return View(tblIl);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IlId,IlAd")] TblIl tblIl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblIl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblIl);
        }

        // GET: City/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIl = await _context.TblIls.FindAsync(id);
            if (tblIl == null)
            {
                return NotFound();
            }
            return View(tblIl);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IlId,IlAd")] TblIl tblIl)
        {
            if (id != tblIl.IlId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblIl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblIlExists(tblIl.IlId))
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
            return View(tblIl);
        }

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIl = await _context.TblIls
                .FirstOrDefaultAsync(m => m.IlId == id);
            if (tblIl == null)
            {
                return NotFound();
            }

            return View(tblIl);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var tblIl = await _context.TblIls.FindAsync(id);
            if (tblIl != null)
            {
                _context.TblIls.Remove(tblIl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblIlExists(short id)
        {
            return _context.TblIls.Any(e => e.IlId == id);
        }
    }
}
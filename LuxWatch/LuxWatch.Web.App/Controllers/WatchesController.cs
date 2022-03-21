using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxWatch.Data;
using LuxWatch.Model;

namespace LuxWatch.Web.App.Controllers
{
    public class WatchesController : Controller
    {
        private readonly AppDbContext _context=new AppDbContext();


        // GET: Watches
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Watches.Include(w => w.Brand).Include(w => w.Category).Include(w => w.Material);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Watches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watches
                .Include(w => w.Brand)
                .Include(w => w.Category)
                .Include(w => w.Material)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // GET: Watches/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Sex");
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Type");
            return View();
        }

        // POST: Watches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefNum,BrandId,Model,Size,MaterialId,CategoryId,ImageUrl,Year,Price")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", watch.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", watch.CategoryId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Type", watch.MaterialId);
            return View(watch);
        }

        // GET: Watches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", watch.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", watch.CategoryId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Type", watch.MaterialId);
            return View(watch);
        }

        // POST: Watches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefNum,BrandId,Model,Size,MaterialId,CategoryId,ImageUrl,Year,Price")] Watch watch)
        {
            if (id != watch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchExists(watch.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", watch.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", watch.CategoryId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Type", watch.MaterialId);
            return View(watch);
        }
        [HttpGet]
        public IActionResult Search()
        {
            List<Watch> products = new List<Watch>();
            return View(products);
        }
        [HttpPost]
        public IActionResult Search(int minprice, int maxprice)
        {
            List<Watch> products = _context.Watches
                .Where(x => x.Price >= minprice && x.Price <= maxprice)
                .ToList();
            return View(products);
        }


        // GET: Watches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watches
                .Include(w => w.Brand)
                .Include(w => w.Category)
                .Include(w => w.Material)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchExists(int id)
        {
            return _context.Watches.Any(e => e.Id == id);
        }
    }
}

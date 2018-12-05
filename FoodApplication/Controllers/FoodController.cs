using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodApplication.Models;
using FoodApplication.ViewModels;

namespace FoodApplication.Controllers
{
    public class FoodController : Controller
    {
        private readonly MyFoodDbContext _context;

        public FoodController(MyFoodDbContext context)
        {
            _context = context;
        }

        // GET: Food
        public async Task<IActionResult> Index()
        {
            var myFoodDbContext = _context.FoodTable.Include(f => f.Category).Include(f => f.MealType);
            return View(await myFoodDbContext.ToListAsync());
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTable = await _context.FoodTable
                .Include(f => f.Category)
                .Include(f => f.MealType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodTable == null)
            {
                return NotFound();
            }

            return View(foodTable);
        }

        // GET: Food/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryTypes,"Id","CategoryType");
            ViewData["MealTypeId"] = new SelectList(_context.MealTypes,"Id","MealType");
            var currentDate = new FoodTable { DateOfConsumption = DateTime.UtcNow };
            return View(currentDate);
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodName,DateOfConsumption,Amount,MealTypeId,CategoryId")] FoodTable foodTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTypes,"Id","CategoryType");
            ViewData["MealTypeId"] = new SelectList(_context.MealTypes,"Id","MealType");
            return View(foodTable);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodViewModel = await _context.FoodTable.FindAsync(id);
            if (foodViewModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTypes, "Id","CategoryType",foodViewModel.Category);
            ViewData["MealTypeId"] = new SelectList(_context.MealTypes, "Id","MealType",foodViewModel.MealType);
            return View(foodViewModel);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,DateOfConsumption,Amount,MealTypeId,CategoryId")] FoodTable foodTable)
        {
            if (id != foodTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTableExists(foodTable.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.CategoryTypes,"Id","CategoryType",foodTable.Category);
            ViewData["MealTypeId"] = new SelectList(_context.MealTypes,"Id","MealType",foodTable.MealType);
            return View(foodTable);
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodViewModel = await _context.FoodTable
                .Include(f => f.Category)
                .Include(f => f.MealType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodViewModel == null)
            {
                return NotFound();
            }

            return View(foodViewModel);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodViewModel = await _context.FoodTable.FindAsync(id);
            _context.FoodTable.Remove(foodViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodTableExists(int id)
        {
            return _context.FoodTable.Any(e => e.Id == id);
        }
    }
}

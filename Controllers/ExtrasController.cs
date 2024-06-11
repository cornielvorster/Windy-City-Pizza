﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Windy_City_Pizza.Data;
using Windy_City_Pizza.Models;

namespace Windy_City_Pizza.Controllers
{
    public class ExtrasController : Controller
    {
        private readonly Windy_City_PizzaContext _context;

        public ExtrasController(Windy_City_PizzaContext context)
        {
            _context = context;
        }

        // GET: Extras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Extras.ToListAsync());
        }

        // GET: Extras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extras == null)
            {
                return NotFound();
            }

            return View(extras);
        }

        // GET: Extras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExtraName,PriceSmall,PriceMeduim,PriceLarge")] Extras extras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(extras);
        }

        // GET: Extras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras.FindAsync(id);
            if (extras == null)
            {
                return NotFound();
            }
            return View(extras);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExtraName,PriceSmall,PriceMeduim,PriceLarge")] Extras extras)
        {
            if (id != extras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtrasExists(extras.Id))
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
            return View(extras);
        }

        // GET: Extras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extras == null)
            {
                return NotFound();
            }

            return View(extras);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extras = await _context.Extras.FindAsync(id);
            if (extras != null)
            {
                _context.Extras.Remove(extras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtrasExists(int id)
        {
            return _context.Extras.Any(e => e.Id == id);
        }
    }
}

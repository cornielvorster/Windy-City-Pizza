using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Windy_City_Pizza.Data;
using Windy_City_Pizza.Interfaces;
using Windy_City_Pizza.Models;
using Windy_City_Pizza.Services;


namespace Windy_City_Pizza.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Windy_City_PizzaContext _context;
        private readonly IPizzaNamesRepository _pizzaNamesRepository;
        private readonly IExtraNamesRepository _extraNamesRepository;

        [HttpPost]
        public IActionResult HandleSelection(string selectedPizza)
        {
            // Process the selected pizza (e.g., log it, save it, etc.)
            return Json(new { success = true, pizza = selectedPizza });
        }


        public OrdersController(Windy_City_PizzaContext context, IPizzaNamesRepository pizzaNamesRepository, IExtraNamesRepository extraNamesRepository)
        {
            _pizzaNamesRepository = pizzaNamesRepository;
            _context = context;
            _extraNamesRepository = extraNamesRepository;
        }

        public IActionResult Order()
        {
            var pizzaNames = _pizzaNamesRepository.GetPizzaNames(); 
            ViewData["PizzaNames"] = pizzaNames;

            var extraNames = _extraNamesRepository.GetExtraNames();
            ViewData["ExtraNames"] = extraNames;
            return View();
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pizza,OrderDate,PizzaSize,Extras,TotalPrice,isCompleted")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pizza,OrderDate,PizzaSize,Extras,TotalPrice,isCompleted")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }

        public ActionResult Search()
        {
            return View();  // Forgot the provide a Model here.
        }


    }
}

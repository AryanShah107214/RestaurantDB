﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantDB.Data;
using RestaurantWebApp.Models;

namespace RestaurantDB.Views.FoodMenus
{
    public class FoodMenusController : Controller
    {
        private readonly RestaurantDBContext _context;

        public FoodMenusController(RestaurantDBContext context)
        {
            _context = context;
        }

        // GET: FoodMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodMenu.ToListAsync());
        }

        // GET: FoodMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodMenu = await _context.FoodMenu
                .FirstOrDefaultAsync(m => m.FoodMenuID == id);
            if (foodMenu == null)
            {
                return NotFound();
            }

            return View(foodMenu);
        }

        // GET: FoodMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodMenuID,FoodName,Description,Price,Category")] FoodMenu foodMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodMenu);
        }

        // GET: FoodMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodMenu = await _context.FoodMenu.FindAsync(id);
            if (foodMenu == null)
            {
                return NotFound();
            }
            return View(foodMenu);
        }

        // POST: FoodMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodMenuID,FoodName,Description,Price,Category")] FoodMenu foodMenu)
        {
            if (id != foodMenu.FoodMenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodMenuExists(foodMenu.FoodMenuID))
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
            return View(foodMenu);
        }

        // GET: FoodMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodMenu = await _context.FoodMenu
                .FirstOrDefaultAsync(m => m.FoodMenuID == id);
            if (foodMenu == null)
            {
                return NotFound();
            }

            return View(foodMenu);
        }

        // POST: FoodMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodMenu = await _context.FoodMenu.FindAsync(id);
            _context.FoodMenu.Remove(foodMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodMenuExists(int id)
        {
            return _context.FoodMenu.Any(e => e.FoodMenuID == id);
        }
    }
}

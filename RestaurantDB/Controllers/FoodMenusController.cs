using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantDB.Data;
using RestaurantDB.Models;

namespace RestaurantDB.Views.FoodMenus
{
    public class FoodMenusController : Controller
    {
        private readonly RestaurantDBContext _context;
        private readonly IWebHostEnvironment _webHostEnv;

        public FoodMenusController(RestaurantDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnv = webHostEnvironment;
        }

        // GET: FoodMenus


        public ActionResult Index(string searchBy, string search)
        {
            //enables the search bar to filter properly
            if (searchBy == "FoodName")
            {
                return View(_context.FoodMenu.Where(x => x.FoodName.StartsWith(search) || search == null).ToList());

            }
            else if(searchBy == "Category")
            {
                return View(_context.FoodMenu.Where(x => x.Category.StartsWith(search) || search == null).ToList());

            }
            else
            {
                return View(_context.FoodMenu.OrderBy(x => x.FoodName).ToList());
            }
        }

        //Displays only records with the category - entrees on this page
        public ActionResult Entrees()
        {
            return View(_context.FoodMenu.Where(x => x.Category == "Entrees").ToList());
        }

        //Displays only records with the category - mains on this page
        public ActionResult Mains()
        {
            return View(_context.FoodMenu.Where(x => x.Category == "Mains").ToList());
        }

        //Displays only records with the category - deserts on this page
        public ActionResult Deserts()
        {
            return View(_context.FoodMenu.Where(x => x.Category == "Deserts").ToList());
        }

        //Displays only records with the category - drinks on this page
        public ActionResult Drinks()
        {
            return View(_context.FoodMenu.Where(x => x.Category == "Drinks").ToList());
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
        public async Task<IActionResult> Create([Bind("FoodMenuID,FoodName,Description,Price,Category,FoodPhoto")] FoodMenu foodMenu)
        {
            if (ModelState.IsValid)
            {
                if (foodMenu.FoodPhoto != null)
                {
                    //adds the image to the record by saving it in the Foods folder
                    string folder = "images/Foods/";
                    folder += Guid.NewGuid().ToString() + "_" + foodMenu.FoodPhoto.FileName;
                    foodMenu.PhotoPath = folder;
                    string serverFolder = Path.Combine(_webHostEnv.WebRootPath, folder);
                    await foodMenu.FoodPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }


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
        public async Task<IActionResult> Edit(int id, [Bind("FoodMenuID,FoodName,Description,Price,Category,FoodPhoto")] FoodMenu foodMenu)
        {
            if (id != foodMenu.FoodMenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (foodMenu.FoodPhoto != null)
                {
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + foodMenu.FoodPhoto.FileName;

                    foodMenu.PhotoPath = folder;

                    string serverFolder = Path.Combine(_webHostEnv.WebRootPath, folder);

                    await foodMenu.FoodPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
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

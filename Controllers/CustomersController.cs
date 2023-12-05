using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShopStore.Data;
using MusicShopStore.Models;

namespace MusicShopStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MusicShopStoreContext _context;

        public CustomersController(MusicShopStoreContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string SearchGenre, string SearchArtist)
        {
            /*
              return _context.Music != null ? 
                          View(await _context.Music.ToListAsync()) :
                          Problem("Entity set 'MusicShopStoreContext.Music'  is null.");
            */
            var showAll = from m in _context.Music
                          select m;

            if (!String.IsNullOrEmpty(SearchGenre))
            {

                showAll = showAll.Where(s => s.Genre.Contains(SearchGenre));
            }
            if (!String.IsNullOrEmpty(SearchArtist))
            {

                showAll = showAll.Where(s => s.Artist.Contains(SearchArtist));
            }

            return View(await showAll.ToListAsync());

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.MusicId == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        public async Task<IActionResult> ShoppingCart(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.MusicId == id);


            if (music == null)
            {
                return NotFound();
            }


            return View(music);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicId,Title,Artist,Genre,Type,Price")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        private bool MusicExists(int id)
        {
          return (_context.Music?.Any(e => e.MusicId == id)).GetValueOrDefault();
        }
    }
}

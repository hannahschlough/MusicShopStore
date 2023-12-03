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
        public async Task<IActionResult> Index()
        {
              return _context.Music != null ? 
                          View(await _context.Music.ToListAsync()) :
                          Problem("Entity set 'MusicShopStoreContext.Music'  is null.");
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
        private bool MusicExists(int id)
        {
          return (_context.Music?.Any(e => e.MusicId == id)).GetValueOrDefault();
        }
    }
}

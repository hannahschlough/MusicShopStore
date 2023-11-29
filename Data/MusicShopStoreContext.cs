using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicShopStore.Models;

namespace MusicShopStore.Data
{
    public class MusicShopStoreContext : DbContext
    {
        public MusicShopStoreContext (DbContextOptions<MusicShopStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MusicShopStore.Models.Music> Music { get; set; } = default!;
    }
}

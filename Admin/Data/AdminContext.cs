using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Admin.Models;

namespace Admin.Data
{
    public class AdminContext : DbContext
    {
        public AdminContext (DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public DbSet<Admin.Models.Produk> Produk { get; set; } = default!;
        public DbSet<Admin.Models.Transaksi> Transaksi { get; set; } = default!;
        public DbSet<Admin.Models.Karir> Karir { get; set; } = default!;
        public DbSet<Admin.Models.Guest> Guest { get; set; } = default!;
    }
}

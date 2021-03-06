﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MontanhasDeLivros.Models
{
    public class MontanhasDeLivrosContext : DbContext
    {
        public MontanhasDeLivrosContext (DbContextOptions<MontanhasDeLivrosContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}

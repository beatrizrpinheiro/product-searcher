using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Searcher.Models;

namespace Searcher.Data
{
    public class SearcherContext : DbContext
    {
        public SearcherContext (DbContextOptions<SearcherContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}

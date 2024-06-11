using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Windy_City_Pizza.Models;

namespace Windy_City_Pizza.Data
{
    public class Windy_City_PizzaContext : DbContext
    {
        public Windy_City_PizzaContext (DbContextOptions<Windy_City_PizzaContext> options)
            : base(options)
        {
        }

        public DbSet<Windy_City_Pizza.Models.Order> Order { get; set; } = default!;
        public DbSet<Windy_City_Pizza.Models.Pizza> Pizza { get; set; } = default!;
        public DbSet<Windy_City_Pizza.Models.Extras> Extras { get; set; } = default!;
    }
}

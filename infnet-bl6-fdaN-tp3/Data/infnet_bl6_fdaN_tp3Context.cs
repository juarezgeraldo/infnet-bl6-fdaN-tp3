using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using infnet_bl6_fdaN_tp3.Models;

namespace infnet_bl6_fdaN_tp3.Data
{
    public class infnet_bl6_fdaN_tp3Context : DbContext
    {
        public infnet_bl6_fdaN_tp3Context (DbContextOptions<infnet_bl6_fdaN_tp3Context> options)
            : base(options)
        {
        }

        public DbSet<infnet_bl6_fdaN_tp3.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Daily_Correspondence.Models;

namespace Daily_Correspondence.Data
{
    public class Daily_CorrespondenceContext : DbContext
    {
        public Daily_CorrespondenceContext (DbContextOptions<Daily_CorrespondenceContext> options)
            : base(options)
        {
        }

        public DbSet<Daily_Correspondence.Models.Movie> Movie { get; set; } = default!;
        public DbSet<Daily_Correspondence.Models.Letter> Letter { get; set; } = default!;
    }
}

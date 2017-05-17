using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitPortfolio.Models
{
    public class GitPortfolioContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public GitPortfolioContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GitPortfolio;integrated security=True;");
        }

        public GitPortfolioContext(DbContextOptions<GitPortfolioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;

namespace VezeetaApi.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

       public DbSet<Author> authors { get; set; }   
       public DbSet<Book> books { get; set; } 
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Specalization> specalizations { get; set; }
        public DbSet<Requests> requests { get; set; }





    }
}

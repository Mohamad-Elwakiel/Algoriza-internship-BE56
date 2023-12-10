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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    UserName =  "Ah",
                    Id = "1",
                    accountType = "Doctor",
                    Email = "DoctorTest@test.com",
                    PasswordHash = null,
                    DOB = (Microsoft.VisualBasic.DateFormat)(22 -10-2023),
                    FirstName = "Mohamad",
                    LastName = "Elwakiel",
                    gender=0,
                    PhoneNumber = "011215",
                    



                });
            modelBuilder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    UserName = "Mo", 
                    Id="2",
                    accountType = "Patient",
                    Email = "PatientTest@test.com",
                    PasswordHash = null,
                    DOB = (Microsoft.VisualBasic.DateFormat)(22 - 10 - 2023),
                    FirstName = "Ahmad",
                    LastName = "Hassan",
                    gender = 0,
                    PhoneNumber = "011215",

                });
            modelBuilder.Entity<Patient>()
                .HasData(new Patient
                {
                    PatientId = 1,
                    Email = "PatientTest@test.com",
                   
                });
            modelBuilder.Entity<Doctors>()
                .HasData(new Doctors
                {
                    DoctorsId = 1,
                    UserId = "1",
                    SpeclizationID = 1,
                });
            modelBuilder.Entity<Specalization>()
                .HasData(new Specalization
                {
                    SpecalizationId = 1,
                    DoctorId = 1,
                    SpecalizationName = "pediatrician",
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

       
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Specalization> specalizations { get; set; }
        public DbSet<Requests> requests { get; set; }
        public DbSet<Discount> discounts { get; set; }  





    }
}

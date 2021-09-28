using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaOnline.Models;

namespace BibliotekaOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ksiazka> Ksiazkas { get; set; }
        public DbSet<Rezerwacja> Rezerwacjas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Ksiazka>().HasOne(a=>a.Rezerwacjas).WithMany(rez)

        }
    }
}

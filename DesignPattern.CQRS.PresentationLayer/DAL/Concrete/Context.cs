﻿using DesignPattern.CQRS.PresentationLayer.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.PresentationLayer.DAL.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O6Q5UAT;initial catalog=CQRSDb; User Id=sa;Password=1234;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Core
{
    public class PeopleManagerDBContext : DbContext
    {
        public PeopleManagerDBContext(DbContextOptions<PeopleManagerDBContext> options) : base(options)
        {

        }

        public DbSet<Person> People => Set<Person>();

        public void Seed()
        {
            People.AddRange(new List<Person>
            {
                new Person { Id = 1, FirstName = "Bavo", LastName = "Ketels", Email = "bavo.ketels@vives.be" },
                new Person { Id = 2, FirstName = "Isabelle", LastName = "Vandoorne", Email = "isabelle.vandoorne@vives.be" },
                new Person { Id = 3, FirstName = "Wim", LastName = "Engelen", Email = "wim.engelen@vives.be" },
                new Person { Id = 4, FirstName = "Ebe", LastName = "Deketelaere", Email = "ebe.deketelaere@vives.be" }
            });
            SaveChanges();
        }
    }
}

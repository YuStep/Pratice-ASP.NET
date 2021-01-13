using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testir.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persones { get; set; } 
        public DbSet<PFRStorage> Storages { get; set; }
        

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

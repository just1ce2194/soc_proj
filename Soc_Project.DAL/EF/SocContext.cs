using Soc_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.EF
{
    public class SocContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public SocContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<SocContext>(new StoreDbInitializer());
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<SocContext>
        {
            protected override void Seed(SocContext db)
            {
                db.Persons.Add(new Person()
                {
                    FirstName = "Denis",
                    LastName = "Storoshenko",
                    MiddleName = "Sergiyovich",
                    VkId = "denstden"
                });
                db.Persons.Add(new Person()
                {
                    FirstName = "Vitaliy",
                    LastName = "Zholobitskiy",
                    MiddleName = "Ivanovich",
                    VkId = "id232948205",
                    LinkedInId = "just1ce2194"
                });
                db.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Jobs)
                .WithRequired(p => p.Person);

            modelBuilder.Entity<Organization>()
               .HasMany(p => p.Jobs)
               .WithRequired(p => p.Organization);

            base.OnModelCreating(modelBuilder);
        }
    }
}

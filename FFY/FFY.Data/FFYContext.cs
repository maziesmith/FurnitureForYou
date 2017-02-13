using FFY.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data
{
    public class FFYContext : DbContext
    {
        public FFYContext() : base("FurnitureForYou")
        {
        }

        public virtual IDbSet<Adress> Adresses { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Room> Rooms { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

using FFY.Data.Contracts;
using FFY.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace FFY.Data
{
    public class FFYContext : IdentityDbContext<User>, IFFYContext
    {
        public FFYContext() : base("FurnitureForYou")
        {
        }

        public virtual IDbSet<Address> Adresses { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Room> Rooms { get; set; }

        public static FFYContext Create()
        {
            return new FFYContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        IDbSet<T> IFFYContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}

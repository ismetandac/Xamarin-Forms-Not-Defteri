using NotDefterim.Model.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefterim.Model
{
    public class Veritabanim : DbContext
    {
        public Veritabanim()
            : base("NotDefteriDB")
        {

        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Not> Not { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}

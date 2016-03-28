
using Inspired.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CatsInTheBox.DAL
{
    public class CatsInTheBoxContext : DbContext
    {
        public CatsInTheBoxContext() : base("CatsInTheBoxContext")
        {
        }

        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Cat> Cat { get; set; }
        public virtual DbSet<Catbreeds> Catbreeds { get; set; }
        public virtual DbSet<Catcoatcolors> Catcoatcolors { get; set; }
        public virtual DbSet<Coatcolor> Coatcolor { get; set; }
        public virtual DbSet<Coatpattern> Coatpattern { get; set; }
        public virtual DbSet<Eyecolor> Eyecolor { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
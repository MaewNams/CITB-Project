
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
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Adopter> Adopter { get; set; }
        public virtual DbSet<Adoption> Adoption { get; set; }
        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Cat> Cat { get; set; }
        public virtual DbSet<Catbreed> Catbreed { get; set; }
        public virtual DbSet<Catcoatcolor> Catcoatcolor { get; set; }
        public virtual DbSet<Catdiary> Catdiary { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Chaptercomment> Chaptercomment { get; set; }
        public virtual DbSet<Coatcolor> Coatcolor { get; set; }
        public virtual DbSet<Coatpattern> Coatpattern { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eyecolor> Eyecolor { get; set; }
        public virtual DbSet<Favoritetopic> Favoritetopic { get; set; }
        public virtual DbSet<Findowner> Findowner { get; set; }
        public virtual DbSet<Followdiary> Followdiary { get; set; }
        public virtual DbSet<Followtopic> Followtopic { get; set; }
        public virtual DbSet<Lostcat> Lostcat { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Reporttopic> Reporttopic { get; set; }
        public virtual DbSet<SOS> SOS { get; set; }
        public virtual DbSet<Tail> Tail { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Topiccomment> Topiccomment { get; set; }
        public virtual DbSet<Topictype> Topictype { get; set; }
        public virtual DbSet<Usertype>Usertype { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
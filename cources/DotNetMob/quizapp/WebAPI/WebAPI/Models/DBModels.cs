namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Qn)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.ImageName)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Option1)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Option2)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Option3)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Option4)
                .IsUnicode(false);
        }
    }
}

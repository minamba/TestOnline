using System;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coreEntityFramework
{
    public partial class MyFirstFullStackApp_DevContext : DbContext
    {
        public MyFirstFullStackApp_DevContext()
        {
        }

        public MyFirstFullStackApp_DevContext(DbContextOptions<MyFirstFullStackApp_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(25);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answer__Question__3E52440B");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Candidate__TestI__398D8EEE");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__Result__AnswerId__45F365D3");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Result__Candidat__44FF419A");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TestQuestion>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TestQuest__Quest__4222D4EF");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__TestQuest__TestI__412EB0B6");
            });
        }
    }
}

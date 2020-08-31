using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineExamApp.Model
{
    public partial class examlibrarydbContext : DbContext
    {
        public examlibrarydbContext()
        {
        }

        public examlibrarydbContext(DbContextOptions<examlibrarydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignedtesttable> Assignedtesttable { get; set; }
        public virtual DbSet<Choicetable> Choicetable { get; set; }
        public virtual DbSet<Customeraccount> Customeraccount { get; set; }
        public virtual DbSet<Customerrole> Customerrole { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Simtest> Simtest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;database=examlibrarydb;user id=root;password=test123#; port=3306");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignedtesttable>(entity =>
            {
                entity.HasKey(e => e.AssignedTestId)
                    .HasName("PRIMARY");

                entity.ToTable("assignedtesttable");

                entity.HasIndex(e => e.EmailId)
                    .HasName("CustId_idx");

                entity.Property(e => e.AssignedTestId).HasColumnName("AssignedTestID");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Assignedtesttable)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("EmailId");
            });

            modelBuilder.Entity<Choicetable>(entity =>
            {
                entity.HasKey(e => e.ChoiceId)
                    .HasName("PRIMARY");

                entity.ToTable("choicetable");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("QuestionID_idx");

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.ChoiceFour)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChoiceOne)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChoiceThree)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChoiceTwo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Choicetable)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("QuestionID");
            });

            modelBuilder.Entity<Customeraccount>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PRIMARY");

                entity.ToTable("customeraccount");

                entity.HasIndex(e => e.CustId)
                    .HasName("CustId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("RoleId_idx");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasColumnType("blob");

                entity.Property(e => e.PasswordSalt).HasColumnType("blob");

                entity.Property(e => e.State)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customeraccount)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("RoleId");
            });

            modelBuilder.Entity<Customerrole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("customerrole");

                entity.Property(e => e.RoleId).HasColumnName("Role ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PRIMARY");

                entity.ToTable("questions");

                entity.HasIndex(e => e.TestId)
                    .HasName("TestId_idx");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("TestId");
            });

            modelBuilder.Entity<Simtest>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PRIMARY");

                entity.ToTable("simtest");

                entity.HasIndex(e => e.EmailId)
                    .HasName("custid_idx");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Simtest)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("custid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

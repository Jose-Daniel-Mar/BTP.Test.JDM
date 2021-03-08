using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public partial class BTPJDMContext : DbContext
    {
        public BTPJDMContext()
        {
        }

        public BTPJDMContext(DbContextOptions<BTPJDMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentsStudent> AssignmentsStudents { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               //optionsBuilder.UseSqlServer("Server=KULA\\SQLEXPRESS;Database=BTPJDM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<AssignmentsStudent>(entity =>
            {
                entity.ToTable("AssignmentsStudent");
                entity.HasOne(d => d.IdAssignmentNavigation).WithMany(p => p.AssignmentsStudents).HasForeignKey(d => d.IdAssignment).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignmentsStudent_Assignments1");
                entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.AssignmentsStudents).HasForeignKey(d => d.IdStudent).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignmentsStudent_Students1");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Birth).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

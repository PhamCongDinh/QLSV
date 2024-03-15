using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLDT.Models;

public partial class QlsvContext : DbContext
{
    public QlsvContext()
    {
    }

    public QlsvContext(DbContextOptions<QlsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Cohort> Cohorts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherClassCour> TeacherClassCours { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-TGUQGH9P\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__account__3213E83FBBB61829");

            entity.ToTable("account");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Images)
                .HasMaxLength(50)
                .HasColumnName("images");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Town)
                .HasMaxLength(50)
                .HasColumnName("town");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classes__3213E83F1D1A8BF4");

            entity.ToTable("classes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviations)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abbreviations");
            entity.Property(e => e.ClassesName)
                .HasMaxLength(50)
                .HasColumnName("classes_name");
            entity.Property(e => e.IdCoh).HasColumnName("id_coh");

            entity.HasOne(d => d.IdCohNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdCoh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classes__id_coh__797309D9");
        });

        modelBuilder.Entity<Cohort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cohort__3213E83FB77CE0FC");

            entity.ToTable("cohort");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviations)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abbreviations");
            entity.Property(e => e.CohortName)
                .HasMaxLength(50)
                .HasColumnName("cohort_name");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Cohorts)
                .HasForeignKey(d => d.IdDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cohort__id_dep__76969D2E");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3213E83FAA7EA10F");

            entity.ToTable("course");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("course_name");
            entity.Property(e => e.IdCoh).HasColumnName("id_coh");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");
            entity.Property(e => e.IdTerm).HasColumnName("id_term");

            entity.HasOne(d => d.IdCohNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdCoh)
                .HasConstraintName("FK__course__id_coh__2B0A656D");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("FK__course__id_dep__2A164134");

            entity.HasOne(d => d.IdTermNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdTerm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__course__id_term__29221CFB");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F8648C3F2");

            entity.ToTable("department");

            entity.HasIndex(e => e.DepartmentName, "UQ__departme__226ED157CB1E74CF").IsUnique();

            entity.HasIndex(e => e.Abbreviations, "UQ__departme__C6D53690C87C4D20").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviations)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abbreviations");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => new { e.IdStu, e.IdCour, e.Number }).HasName("PK__point__6A47659076719F6C");

            entity.ToTable("point");

            entity.Property(e => e.IdStu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_stu");
            entity.Property(e => e.IdCour)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_cour");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PointProcess).HasColumnName("point_process");
            entity.Property(e => e.PointTest).HasColumnName("point_test");

            entity.HasOne(d => d.IdCourNavigation).WithMany(p => p.Points)
                .HasForeignKey(d => d.IdCour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__point__id_cour__2EDAF651");

            entity.HasOne(d => d.IdStuNavigation).WithMany(p => p.Points)
                .HasForeignKey(d => d.IdStu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__point__id_stu__2DE6D218");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3213E83FDCC3ECF6");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.IdClass).HasColumnName("id_class");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__id__0C85DE4D");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__id_clas__0B91BA14");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teacher__3213E83F32DC025D");

            entity.ToTable("teacher");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher__id__0F624AF8");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("FK__teacher__id_dep__10566F31");
        });

        modelBuilder.Entity<TeacherClassCour>(entity =>
        {
            entity.HasKey(e => new { e.IdTeacher, e.IdClass, e.IdCour }).HasName("PK__teacher___1DF6BF6B70CA6008");

            entity.ToTable("teacher_class_cour");

            entity.Property(e => e.IdTeacher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_teacher");
            entity.Property(e => e.IdClass).HasColumnName("id_class");
            entity.Property(e => e.IdCour)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_cour");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.TeacherClassCours)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher_c__id_cl__339FAB6E");

            entity.HasOne(d => d.IdCourNavigation).WithMany(p => p.TeacherClassCours)
                .HasForeignKey(d => d.IdCour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher_c__id_co__32AB8735");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TeacherClassCours)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher_c__id_te__31B762FC");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__term__3213E83FD9CF8985");

            entity.ToTable("term");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.TermName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("term_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

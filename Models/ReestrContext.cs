using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewReestrAsp.Models;

public partial class ReestrContext : DbContext
{
    public ReestrContext()
    {
    }

    public ReestrContext(DbContextOptions<ReestrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<AwardsDocument> AwardsDocuments { get; set; }

    public virtual DbSet<DrizzleMigration> DrizzleMigrations { get; set; }

    public virtual DbSet<GovernmentEmployee> GovernmentEmployees { get; set; }

    public virtual DbSet<GovernmentEmployeesArchive> GovernmentEmployeesArchives { get; set; }

    public virtual DbSet<GovernmentEmployeesEducation> GovernmentEmployeesEducations { get; set; }

    public virtual DbSet<GovernmentEmployeesEducationArchive> GovernmentEmployeesEducationArchives { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("awards_pkey");

            entity.ToTable("awards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.Organization).HasColumnName("organization");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.ReceiptDate).HasColumnName("receipt_date");
            entity.Property(e => e.RegistrationNumber).HasColumnName("registration_number");
            entity.Property(e => e.Text).HasColumnName("text");
        });

        modelBuilder.Entity<AwardsDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("awards_documents_pkey");

            entity.ToTable("awards_documents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAward).HasColumnName("id_award");
            entity.Property(e => e.NameDocument).HasColumnName("name_document");

            entity.HasOne(d => d.IdAwardNavigation).WithMany(p => p.AwardsDocuments)
                .HasForeignKey(d => d.IdAward)
                .HasConstraintName("awards_documents_id_award_awards_id_fk");
        });

        modelBuilder.Entity<DrizzleMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("__drizzle_migrations_pkey");

            entity.ToTable("__drizzle_migrations", "drizzle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Hash).HasColumnName("hash");
        });

        modelBuilder.Entity<GovernmentEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("government_employees_pkey");

            entity.ToTable("government_employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Addres).HasColumnName("addres");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IdUnit).HasColumnName("id_unit");
            entity.Property(e => e.MobileNumber).HasColumnName("mobile_number");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NumberPhoneDivision).HasColumnName("number_phone_division");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Post).HasColumnName("post");
            entity.Property(e => e.StartWorkDate).HasColumnName("start_work_date");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.Temp).HasColumnName("temp");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.GovernmentEmployees)
                .HasForeignKey(d => d.IdUnit)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("government_employees_id_unit_unit_id_fk");
        });

        modelBuilder.Entity<GovernmentEmployeesArchive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("government_employees_archive_pkey");

            entity.ToTable("government_employees_archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Addres).HasColumnName("addres");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Departament).HasColumnName("departament");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.MobileNumber).HasColumnName("mobile_number");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NumberPhoneDivision).HasColumnName("number_phone_division");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Post).HasColumnName("post");
            entity.Property(e => e.StartWorkDate).HasColumnName("start_work_date");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.Temp).HasColumnName("temp");
        });

        modelBuilder.Entity<GovernmentEmployeesEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("government_employees_education_pkey");

            entity.ToTable("government_employees_education");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.EducationalInstitution).HasColumnName("educational_institution");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.Profession).HasColumnName("profession");
            entity.Property(e => e.TypeEducation).HasColumnName("type_education");
            entity.Property(e => e.TypeProfession).HasColumnName("type_profession");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.GovernmentEmployeesEducations)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("government_employees_education_id_employee_government_employees");
        });

        modelBuilder.Entity<GovernmentEmployeesEducationArchive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("government_employees_education_archive_pkey");

            entity.ToTable("government_employees_education_archive");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.EducationalInstitution).HasColumnName("educational_institution");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.Profession).HasColumnName("profession");
            entity.Property(e => e.TypeEducation).HasColumnName("type_education");
            entity.Property(e => e.TypeProfession).HasColumnName("type_profession");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.GovernmentEmployeesEducationArchives)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("government_employees_education_archive_id_employee_government_e");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_pkey");

            entity.ToTable("unit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.UnitName).HasColumnName("unit_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminAccess)
                .HasDefaultValue(0)
                .HasColumnName("admin_access");
            entity.Property(e => e.AwardsAccess)
                .HasDefaultValue(0)
                .HasColumnName("awards_access");
            entity.Property(e => e.EmployeesAccess)
                .HasDefaultValue(1)
                .HasColumnName("employees_access");
            entity.Property(e => e.HashedPassword).HasColumnName("hashed_password");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(0)
                .HasColumnName("is_active");
            entity.Property(e => e.NumberPhone).HasColumnName("number_phone");
            entity.Property(e => e.UnitAccess)
                .HasDefaultValue(0)
                .HasColumnName("unit_access");
            entity.Property(e => e.UserRole).HasColumnName("user_role");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

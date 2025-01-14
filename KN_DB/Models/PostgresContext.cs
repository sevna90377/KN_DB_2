using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KN_DB.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseMember> CourseMembers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionMember> SectionMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=minnie07");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("course_pkey");

            entity.ToTable("course");

            entity.Property(e => e.CourseId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("courseID");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'no available description for this course'::text")
                .HasColumnName("description");
            entity.Property(e => e.LecturerId).HasColumnName("lecturerID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("'course yet unnamed'::character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.Courses)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("course_lecturerID_fkey");
        });

        modelBuilder.Entity<CourseMember>(entity =>
        {
            entity.HasKey(e => e.CourseMemberId).HasName("course_member_pkey");

            entity.ToTable("course_member", tb => tb.HasComment("Table handling the many-to-many relation of 'Course' and 'Member' tables"));

            entity.Property(e => e.CourseMemberId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("course_memberID");
            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.MemberId).HasColumnName("memberID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseMembers)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_member_courseID_fkey");

            entity.HasOne(d => d.Member).WithMany(p => p.CourseMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_member_memberID_fkey");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("member_pkey");

            entity.ToTable("member", tb => tb.HasComment("Currently registered members of the science circle"));

            entity.Property(e => e.MemberId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("memberID");
            entity.Property(e => e.DiscordName)
                .HasColumnType("character varying")
                .HasColumnName("discord_name");
            entity.Property(e => e.IsCouncilMember)
                .HasDefaultValue(false)
                .HasColumnName("is_council_member");
            entity.Property(e => e.JoinDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("join_date");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.ProjectId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("projectID");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'no description available for this project'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasDefaultValueSql("'unnamed project'::character varying")
                .HasColumnName("name");
            entity.Property(e => e.SectionId).HasColumnName("sectionID");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Section).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_sectionID_fkey");
        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.HasKey(e => e.ProjectMemberId).HasName("project_member_pkey");

            entity.ToTable("project_member", tb => tb.HasComment("Table handling the many-to-many relation of 'Project' and 'Member' tables"));

            entity.Property(e => e.ProjectMemberId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("project_memberID");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.ProjectId).HasColumnName("projectID");
            entity.Property(e => e.RoleId).HasColumnName("roleID");

            entity.HasOne(d => d.Member).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_member_memberID_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_member_projectID_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_member_roleID_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("roleID");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'no description for this role availabe'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("section_pkey");

            entity.ToTable("section", tb => tb.HasComment("Student Circle's distinct sections of activity"));

            entity.Property(e => e.SectionId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("sectionID");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'no description available for this section'::text")
                .HasColumnName("description");
            entity.Property(e => e.LeadId).HasColumnName("leadID");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Lead).WithMany(p => p.Sections)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("section_leadID_fkey");
        });

        modelBuilder.Entity<SectionMember>(entity =>
        {
            entity.HasKey(e => e.SectionMemberId).HasName("section_member_pkey");

            entity.ToTable("section_member", tb => tb.HasComment("Table handling the many-to-many relation of 'Section' and 'Member' tables"));

            entity.Property(e => e.SectionMemberId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("section_memberID");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.SectionId).HasColumnName("sectionID");

            entity.HasOne(d => d.Member).WithMany(p => p.SectionMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("section_member_memberID_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionMembers)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("section_member_sectionID_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

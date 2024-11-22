using System;
using System.Collections.Generic;
using Fitness_EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace Fitness_EF.DbContextEF;

public partial class DbContext_Fitness : DbContext
{
    public DbContext_Fitness()
    {
    }

    public DbContext_Fitness(DbContextOptions<DbContext_Fitness> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admin { get; set; }

    public virtual DbSet<Bodydata> Bodydata { get; set; }

    public virtual DbSet<Comment> Comment { get; set; }

    public virtual DbSet<Diary> Diary { get; set; }

    public virtual DbSet<Food> Food { get; set; }

    public virtual DbSet<Like> Like { get; set; }

    public virtual DbSet<Meal> Meal { get; set; }

    public virtual DbSet<Member> Member { get; set; }

    public virtual DbSet<Post> Post { get; set; }

    public virtual DbSet<Workoutlevel> Workoutlevel { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Main_DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.adminID).HasName("PK__Admin__AD050086C75D2BE1");

            entity.HasIndex(e => e.Account, "UQ__Admin__B0C3AC46F1966F8F").IsUnique();

            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.Createtime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Bodydata>(entity =>
        {
            entity.HasKey(e => e.dataID).HasName("PK__Bodydata__923E368516BDB08E");

            entity.Property(e => e.Createtime).HasColumnType("datetime");

            entity.HasOne(d => d.level).WithMany(p => p.Bodydata)
                .HasForeignKey(d => d.levelID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bodydata__levelI__3B75D760");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.commentID).HasName("PK__Comment__CDDE91BD05CA47D6");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Posttime).HasColumnType("datetime");

            entity.HasOne(d => d.post).WithMany(p => p.Comment)
                .HasForeignKey(d => d.postID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__postID__3C69FB99");
        });

        modelBuilder.Entity<Diary>(entity =>
        {
            entity.HasKey(e => e.diaryID).HasName("PK__Diary__E98C9C20F209E749");

            entity.Property(e => e.Createtime).HasColumnType("datetime");

            entity.HasOne(d => d.food).WithMany(p => p.Diary)
                .HasForeignKey(d => d.foodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diary__foodID__398D8EEE");

            entity.HasOne(d => d.time).WithMany(p => p.Diary)
                .HasForeignKey(d => d.timeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diary__timeID__3A81B327");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.foodID).HasName("PK__Food__77EAEA19A4629811");

            entity.Property(e => e.Createtime).HasColumnType("datetime");
            entity.Property(e => e.Foodname).HasMaxLength(30);
            entity.Property(e => e.unit).HasMaxLength(30);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.likeID).HasName("PK__Like__4FC592FB2BD9A8B2");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");

            entity.HasOne(d => d.post).WithMany(p => p.Like)
                .HasForeignKey(d => d.postID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Like__postID__3D5E1FD2");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.timeID).HasName("PK__Meal__965461612DBD07D2");

            entity.Property(e => e.Mealname).HasMaxLength(10);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.memberID).HasName("PK__Member__7FD7CFF6C3EF6F76");

            entity.HasIndex(e => e.Account, "UQ__Member__B0C3AC4695EED352").IsUnique();

            entity.Property(e => e.memberID).HasComment(" 會員編號");
            entity.Property(e => e.Account)
                .HasMaxLength(30)
                .HasComment("帳號");
            entity.Property(e => e.Age)
                .HasComputedColumnSql("(datediff(year,[Birthday],getdate()))", false)
                .HasComment("年齡");
            entity.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnType("datetime");
            entity.Property(e => e.Block)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("封鎖");
            entity.Property(e => e.Createtime)
                .HasComment("建立日期")
                .HasColumnType("datetime");
            entity.Property(e => e.Gender).HasComment("性別");
            entity.Property(e => e.Height)
                .HasComment("身高")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasComment("姓名");
            entity.Property(e => e.Password).HasComment("密碼");
            entity.Property(e => e.Photo).HasComment("照片");
            entity.Property(e => e.Target_Date)
                .HasComment("目標日期")
                .HasColumnType("datetime")
                .HasColumnName("Target Date");
            entity.Property(e => e.Target_Weight)
                .HasComment("目標體重")
                .HasColumnType("decimal(18, 1)")
                .HasColumnName("Target Weight");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.postID).HasName("PK__Post__DD0C73BA4FE5C9B2");

            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Posttime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Workoutlevel>(entity =>
        {
            entity.HasKey(e => e.levelID).HasName("PK__Workoutl__42A46B84C95A3083");

            entity.Property(e => e.Level).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

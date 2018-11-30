using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodApplication.Models
{
    public partial class MyFoodDbContext : DbContext
    {
        public MyFoodDbContext()
        {
        }

        public MyFoodDbContext(DbContextOptions<MyFoodDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTypes> CategoryTypes { get; set; }
        public virtual DbSet<FoodTable> FoodTable { get; set; }
        public virtual DbSet<MealTypes> MealTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MyFoodDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryType).HasMaxLength(10);
            });

            modelBuilder.Entity<FoodTable>(entity =>
            {
                entity.Property(e => e.DateOfConsumption).HasColumnType("datetime");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FoodTable)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_FoodTable_CategoryTypes");

                entity.HasOne(d => d.MealType)
                    .WithMany(p => p.FoodTable)
                    .HasForeignKey(d => d.MealTypeId)
                    .HasConstraintName("FK_FoodTable_MealTypes");
            });

            modelBuilder.Entity<MealTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MealType).HasMaxLength(50);
            });
        }
    }
}

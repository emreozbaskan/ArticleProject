using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Concrete.EntityFramework.Context
{
    using ArticleProject.Entities.Concrete;
    using Castle.Core.Configuration;
    using Core.Entities.Concrete;

    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {
            
        }

        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Article
            modelBuilder.Entity<Article>().HasOne(t0 => t0.UserAccount).WithMany().HasForeignKey(t0 => t0.AuthorId);
            modelBuilder.Entity<Article>().Property(t0 => t0.Tags).HasMaxLength(500);
            modelBuilder.Entity<Article>().Property(t0 => t0.Title).HasMaxLength(500);

            //Category
            modelBuilder.Entity<Category>().HasMany(t0 => t0.Articles).WithOne(t0 => t0.Category).HasForeignKey(t0 => t0.CategoryId);
            modelBuilder.Entity<Category>().HasOne(t0 => t0.ParentCategory).WithMany().HasForeignKey(t0 => t0.ParenCategorytId);
            modelBuilder.Entity<Category>().Property(t0 => t0.CategoryName).HasMaxLength(255);

            //Comment
            modelBuilder.Entity<Comment>().HasOne(t0 => t0.Article).WithMany(t0 => t0.Comments).HasForeignKey(t0 => t0.ArticleId);
            modelBuilder.Entity<Comment>().HasOne(t0 => t0.ParentComment).WithMany().HasForeignKey(t0 => t0.ParentCommentId);
            modelBuilder.Entity<Comment>().HasOne(t0 => t0.UserAccount).WithMany().HasForeignKey(t0 => t0.UserAccountId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().Property(t0 => t0.Content).HasMaxLength(500);


            //UserAccount
            modelBuilder.Entity<UserAccount>().Property(t0 => t0.FirstName).HasMaxLength(255);
            modelBuilder.Entity<UserAccount>().Property(t0 => t0.LastName).HasMaxLength(255);
            modelBuilder.Entity<UserAccount>().Property(t0 => t0.Email).HasMaxLength(500);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=EMREOZBASKAN\\SQL2016;Database=ArticleDb;uid=sa;pwd=1;");
            
        }
    }
}

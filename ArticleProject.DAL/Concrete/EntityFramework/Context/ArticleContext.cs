using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Concrete.EntityFramework.Context
{
    using Core.Entities.Concrete;

    public class ArticleContext : DbContext
    {
        public ArticleContext()
        {

        }

        public DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMREOZBASKAN\\SQL2016;Database=ArticleDb;uid=sa;pwd=1;");
        }
    }
}

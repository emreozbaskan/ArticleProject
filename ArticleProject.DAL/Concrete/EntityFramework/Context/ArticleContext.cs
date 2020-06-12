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

        public DbSet<User> User { get; set; }
    }
}

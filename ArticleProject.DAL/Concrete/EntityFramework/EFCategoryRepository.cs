﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Concrete.EntityFramework
{
    using Abstract;
    using Core.DAL.EntityFramework;
    using Context;
    using Entities.Concrete;

    public class EFCategoryRepository : EFEntityRepositoryBase<Category, ArticleContext>, ICategoryRepository
    {

    }
}

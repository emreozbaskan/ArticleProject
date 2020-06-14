using ArticleProject.Core.Utilities.Result;
using ArticleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int CategoryId);
        IDataResult<List<Category>> GetList();
        IDataResult<Category> Add(Category entity);
        IDataResult<Category> Update(Category entity);
        IResult Delete(Category entity);

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Abstract
{
    using Core.Utilities.Result;
    using Entities.Concrete;

    public interface IArticleService
    {
        IDataResult<Article> GetById(int Id);
        IDataResult<List<Article>> GetList(int skip, int take);
        IDataResult<List<Article>> Search(string search, int skip, int take);
        IDataResult<Article> Add(Article entity);
        IDataResult<Article> Update(Article entity);
        IResult Delete(Article entity);
    }
}

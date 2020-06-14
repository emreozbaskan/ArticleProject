using System;
using System.Collections.Generic;
using System.Text;


namespace ArticleProject.BL.Abstract
{
    using Core.Utilities.Result;
    using Entities.Concrete;

    public interface ICommentService
    {
        IDataResult<Comment> GetById(int Id);
        IDataResult<List<Comment>> GetList(int ArticleId);
        IDataResult<Comment> Add(Comment entity);
        IDataResult<Comment> Update(Comment entity);
        IResult Delete(Comment entity);
    }
}

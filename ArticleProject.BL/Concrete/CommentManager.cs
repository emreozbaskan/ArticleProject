using ArticleProject.BL.Abstract;
using ArticleProject.BL.Contants;
using ArticleProject.Core.Utilities.Result;
using ArticleProject.DAL.Abstract;
using ArticleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticleProject.BL.Concrete
{

    public class CommentManager : ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IDataResult<Comment> Add(Comment entity)
        {
            return new SuccessDataResult<Comment>(_commentRepository.Add(entity), Messages.CommentAdd);
        }

        public IResult Delete(Comment entity)
        {
            return new Result(_commentRepository.Delete(entity), Messages.CommentDelete);
        }

        public IDataResult<Comment> GetById(int Id)
        {
            return new SuccessDataResult<Comment>(_commentRepository.Get(t0 => t0.Id == Id));
        }

        public IDataResult<List<Comment>> GetList(int ArticleId)
        {
            return new SuccessDataResult<List<Comment>>(_commentRepository.GetList(t0 => t0.ArticleId == ArticleId).ToList());
        }

        public IDataResult<Comment> Update(Comment entity)
        {
            return new SuccessDataResult<Comment>(_commentRepository.Update(entity), Messages.CommentUpdate);
        }
    }
}

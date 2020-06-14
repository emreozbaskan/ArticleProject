using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Concrete
{
    using Contants;
    using Abstract;
    using Core.Utilities.Result;
    using DAL.Abstract;
    using Entities.Concrete;
    using System.Linq;

    public class ArticleManager : IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public IDataResult<Article> Add(Article entity)
        {
            entity.RecordDate = DateTime.Now;
            return new SuccessDataResult<Article>(_articleRepository.Add(entity), Messages.ArticleAdd);
        }

        public IResult Delete(Article entity)
        {
            return new Result(_articleRepository.Delete(entity), Messages.ArticleDelete);
        }

        public IDataResult<Article> GetById(int Id)
        {
            return new SuccessDataResult<Article>(_articleRepository.Get(t0 => t0.Id == Id));
        }

        public IDataResult<List<Article>> GetList(int skip, int take)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetPaggingList(t0 => t0.IsPublish == true, skip, take));
        }

        public IDataResult<List<Article>> Search(string search, int skip, int take)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetPaggingList(
                t0 => t0.IsPublish == true &&
                (t0.Title.Contains(search) || t0.Content.Contains(search))
                , skip, take)
                );
        }

        public IDataResult<Article> Update(Article entity)
        {
            entity.UpdateDate = DateTime.Now;
            return new SuccessDataResult<Article>(_articleRepository.Update(entity), Messages.ArticleUpdate);
        }
    }
}

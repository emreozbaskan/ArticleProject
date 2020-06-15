using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ArticleProject.BL.Concrete
{
    using Contants;
    using Abstract;
    using Core.Utilities.Result;
    using DAL.Abstract;
    using Entities.Concrete;
    using Core.Aspects.Autofac.Caching;
    using Core.Aspects.Autofac.Logging;
    using Core.CrossCuttingConcerns.Logging.Loggers;

    public class ArticleManager : IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [LogAspect(typeof(FileLogger))] //Loglama işlemi 
        [CacheRemoveAspect("IArticleService.Get")]
        public IDataResult<Article> Add(Article entity)
        {
            entity.RecordDate = DateTime.Now;
            return new SuccessDataResult<Article>(_articleRepository.Add(entity), Messages.ArticleAdd);
        }

        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IArticleService.Get")]
        public IResult Delete(Article entity)
        {
            return new Result(_articleRepository.Delete(entity), Messages.ArticleDelete);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<Article> GetById(int Id)
        {
            return new SuccessDataResult<Article>(_articleRepository.Get(t0 => t0.Id == Id));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Article>> GetList(int skip, int take)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetPaggingList(t0 => t0.IsPublish == true, skip, take));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Article>> GetSearch(string search, int skip, int take)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetPaggingList(
                t0 => t0.IsPublish == true &&
                (t0.Title.Contains(search) || t0.Content.Contains(search))
                , skip, take)
                );
        }

        [CacheRemoveAspect("IArticleService.Get")]
        public IDataResult<Article> Update(Article entity)
        {
            entity.UpdateDate = DateTime.Now;
            return new SuccessDataResult<Article>(_articleRepository.Update(entity), Messages.ArticleUpdate);
        }
    }
}

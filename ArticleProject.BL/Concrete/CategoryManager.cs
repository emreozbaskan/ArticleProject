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

    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IDataResult<Category> Add(Category entity)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Add(entity), Messages.CategoryAdd);
        }

        public IResult Delete(Category entity)
        {
            return new Result(_categoryRepository.Delete(entity), Messages.CategoryDelete);
        }

        public IDataResult<Category> GetById(int CategoryId)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(t0 => t0.Id == CategoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetList().ToList());
        }

        public IDataResult<Category> Update(Category entity)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Update(entity), Messages.CategoryUpdate);
        }
    }
}

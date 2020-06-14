using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Entities.Concrete
{
    using Core.Entities.Abstract;

    public class Category:IEntity
    {
        public int Id { get; set; }

        public int? ParenCategorytId { get; set; }
        public Category ParentCategory { get; set; }

        public string CategoryName { get; set; }

        public List<Article> Articles { get; set; }
    }
}

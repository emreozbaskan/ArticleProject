using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Entities.Concrete
{
    using Core.Entities.Abstract;
    using Core.Entities.Concrete;

    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public string Content { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}

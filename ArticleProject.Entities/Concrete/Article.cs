using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Entities.Concrete
{
    using ArticleProject.Core.Entities.Concrete;
    using Core.Entities.Abstract;

    public class Article : IEntity
    {
        //Id
        public int Id { get; set; }
        //Başlık
        public string Title { get; set; }
        //Yazı
        public string Content { get; set; }

        //Kategori
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        //tags
        public string Tags { get; set; }

        //Yazı Yayındamı
        public bool IsPublish { get; set; }
        //Kayıt Tarih
        public DateTime RecordDate { get; set; }
        //Güncelleme Tarih
        public DateTime UpdateDate { get; set; }
        //Yazının Sahibi
        public int AuthorId { get; set; }
        public UserAccount UserAccount { get; set; }
        //Yorumlar
        public List<Comment> Comments { get; set; }


    }
}

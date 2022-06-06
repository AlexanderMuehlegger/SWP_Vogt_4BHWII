using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Article {

        private int _articleId;

        public int ArticleId {
            get { return this._articleId; }
            set {
                if(value >= 0)
                {
                    this._articleId = value;
                }
            }
        }

        public string ArticleName { get; set; }
        public string Brand { get; set; }
        public DateTime ReleaseDate { get; set; }

        //ctor's + ToString()

    }
}

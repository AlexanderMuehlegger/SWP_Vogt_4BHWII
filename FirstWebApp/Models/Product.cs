using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Product {

        private int _productId;

        public int ProductId {
            get { return this._productId; }
            set {
                if(value >= 0)
                {
                    this._productId = value;
                }
            }
        }

        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}

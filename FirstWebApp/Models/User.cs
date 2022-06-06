using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class User {

        private int _userId;

        public int UserId {
            get { return this._userId; }
            set {
                if(value >= 0)
                {
                    this._userId = value;
                }
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime Birthdate { get; set; }

        public string EMail { get; set; }

        public Gender Gender { get; set; }

        //ctor's + ToString()


    }
}

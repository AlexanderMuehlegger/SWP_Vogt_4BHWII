using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Student {

        private int _studentId;

        public int StudentId {
            get { return _studentId; }
            set {
                if(value >= 0)
                {
                    _studentId = value;
                }
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

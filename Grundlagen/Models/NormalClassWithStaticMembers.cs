using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {
    class NormalClassWithStaticMembers {

        //normale Members
        public string Text { get; set; }
        public double Do() {
            return 100;
        }


        //statische Members
        public static double Value { get; set; }
        public static string DoStatic() {
            //Text = "Hallo"; nicht erlaubt, da man nur auf statische Members innerhalb einer statischen
            //Methode zugreifen darf

            return "statischer Text";
        }
    }
}

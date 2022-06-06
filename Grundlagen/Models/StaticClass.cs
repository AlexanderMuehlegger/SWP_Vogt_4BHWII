using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //statische Klasse: alle Members (Methoden, Felder) müssen static sein
    //beim Aufruf im Hauptprogramm muss nur der Klassenname + Member angegeben werden
    //      -> es muss keine Instanz/Objekt erzeugt werden
    static class StaticClass {

        public static double PI = 3.1415;

        public static double Add(double z1, double z2) {
            return z1 + z2;
        }
    }
}

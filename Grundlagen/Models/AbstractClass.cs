using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //abstrakte Klasse: kann normale Methoden enthalten und sie kann abstrakte Methoden (kein Programmcode enthalten)
    //besitzen
    //von einer abstrakten Klasse kann keine Instanz/Objekt erzeugt werden
    //      z.B. AbstractClass a  new AbstractClass(); funktioniert nicht
    abstract class AbstractClass {

        //normale Methoden
        public string Do() {
            return "Hallo";
        }

        //abstrakte Methoden
        abstract public double Calculate();
    }
}

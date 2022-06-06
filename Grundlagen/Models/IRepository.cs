using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //Interface: es sind nur die Methodenköpfe enthalten
    //es ist kein Programmcode enthalten
    //ist ein Vertrag: es werden nur die Methodensignaturen angegeben
    //=> Klassen, welche das Interface implementieren, müssen alle Methoden ausprogrammieren
    interface IRepository {
        void Open();
        void Close();
        bool Insert(Person p);
        //usw.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //Vererbung: Student erbt alles von Person
    //ctors werden nicht vererbt, diese Müssen neu programmiert werden
    //  public ... man hat von überall aus Zugriff auf public-Members (Felder/Methoden)
    //  protected ... nur die Klasse selber und alle Unterklassen haben auf protected-Members Zugriff
    //  private ... nur die Klasse hat auf private-Members Zugriff
    class Student : Person{

        public string SClass { get; set; }

        public Student() 
            : this(0, "", "", Department.notSpecified, DateTime.MinValue, 0.0m, "")
        {

        }

        public Student(int persId, string firstname, string lastname,
            Department dep, DateTime birthdate, decimal salary, string sClass)
            : base(persId, firstname, lastname, dep, birthdate, salary)
        {
            //alle neuen Felder werden hier belegt
            this.SClass = sClass;
        }

        public override string ToString() {
            //base ... Zugriff auf die Members der Basisklasse
            return base.ToString() + "" + this.SClass;
        }

    }
}

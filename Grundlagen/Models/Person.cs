using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models
{
    class Person   
    {
        // fields (sollten immer private sein)
        private int personId;
        private decimal salary;
        private DateTime birthdate;
        // Properties (sind die getter/setter von JAVA
        //  - automatische Properties
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Department Department { get; set; }
        //  - normale Properties
        public int PersonId
        {
            get { return this.personId; }
            set {
                if ( value >= 0)
                {
                    this.personId = value;
                }
            }

        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if(value >= 0)
                {
                    this.salary = value;
                }
            }
        }

        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set
            {
                if(value < DateTime.Now)
                {
                    this.birthdate = value;
                }
            }
        }

        public string Name
        {
            get { return this.Lastname + " " + this.Firstname; }
        }

        // ctors (Konstruktor)
        public Person() : this(0, "", "", Department.notSpecified, DateTime.MinValue, (decimal) 0.0)
        {

        }

        public Person(int persId, string firstname, string lastname,
            Department dep, DateTime birthdate, decimal salary)
        {
            this.PersonId = persId;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Department = dep;
            this.Birthdate = birthdate;
            this.Salary = salary;
        }



        //ToString() + other methods
        public override string ToString()
        {
            return this.personId + " " + this.Firstname + " " + this.Lastname + "\n" +
                this.Department + "" + this.salary + " Euro " + this.Birthdate.ToLongDateString();
        }


    }
}

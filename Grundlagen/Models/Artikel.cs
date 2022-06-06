using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {
    class Artikel {
        //fields
        private int artikelId;
        private decimal preis;
        //Properties
        // - automatisch
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Artikelart Artikelart { get; set; }

        // - normal
        public int ArtikelId {
            get { return this.artikelId; }
            set {
                if(value >= 0)
                {
                    this.artikelId = value;
                }
            }
        }

        public decimal Preis {
            get { return this.preis; }
            set {
                if (value >= 0)
                {
                    this.preis = value;
                }
            }
        }
        //Konstruktoren
        public Artikel() : this(0, "", "", Artikelart.notSpecified, 0.0m) { }

        public Artikel(int artikelId, string name, string beschreibung, Artikelart artikelart, decimal preis) {
            this.ArtikelId = artikelId;
            this.Name = name;
            this.Beschreibung = beschreibung;
            this.Artikelart = artikelart;
            this.Preis = preis;
        }
        //toString + other Methods
        public override string ToString() {
            return this.ArtikelId + " " + this.Name + " " + this.Beschreibung + " " + this.Artikelart + " " +
                this.Preis + " Euro ";
        }

    }
}

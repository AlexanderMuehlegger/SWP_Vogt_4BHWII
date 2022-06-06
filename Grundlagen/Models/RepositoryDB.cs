using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //die Klasse RepositoryDB implementiert das Interface IRepository
    //Eine Klasse darf nur von einer Klasse erben, sie darf aber beliebig viele Interfaces implementieren
    class RepositoryDB : IRepository {
        public void Close() {
            //Code, um die Verbindung zur DB zu schließen
            throw new NotImplementedException();
        }

        public bool Insert(Person p) {
            //Code, um eine Person in der DB abzulegen
            throw new NotImplementedException();
        }

        public void Open() {
            //Code, um die DB-Verbindung zu öffnen
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Message {

        public string Header { get; set; }
        public string MessageText { get; set; }
        public String Solution { get; set; }


        public Message() : this("", "", "") { }
        //für Erfolgsmeldungen
        public Message(string header, string message)
            : this(header, message, ""){ }
        //für Fehlermeldungen
        public Message(string header, string message, string solution) {
            this.Header = header;
            this.MessageText = message;
            this.Solution = solution;
        }
    }
}

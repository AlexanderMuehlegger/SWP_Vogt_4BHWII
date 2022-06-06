

//              meisten Browsern)

// ready() ist eine Funcktion auf dem jQuery-Object $
//      es wird gewartet, bis das html-Dokument komplett geladen wurde
//      erst dann kann man auf alle Elemente sicher zugreifen

$(document).ready(() => {
    alert("ready ")
    //$ ist eine kurze Schreibweise für document.getElementById/Class/Tag
    //blur() ist ein Ereignishandler .. blur wird aufgerufen, wenn dieses Element (#EMail) den Focus verliert
    $("#EMail").blur(() => {
        // AJAX-Request: die eingeg. Mail-Adresse soll an den server gesendet werden
        //  dort wird überprüft, ob die Email-Adresse vorhanden ist
        //  falls ja, Meldung anzeigen
        //  falls nein, alles ok
        // AJAX ... asynchronous javascript and XML (statt XML wird J<SON verwendet)
        //      -> es wird ein asynchroner Aufruf an den Server gesendet
        $.ajax({
            //wohin soll der request gehen
            url: "/user/checkEmail",
            //HttpMethode angeben
            method: "GET",
            //die zu übermittelnden Daten angeben
            data: {
                email: $('#EMail').val()
            }
        })
            //diese Methode wird aufgerufen, falls der Server/ die URL erfolgreich aufgerufen werden 
            .done((serverData) => {
                //alert("Server/URL erreichbar! " + serverData)
                //falls die Email vorhanden ist soll eine Fehlermeldung angezeigt weden
                if (serverData == true) {
                    $("#Email-Double").css("display", "block")
                    $("#EMail").addClass("redBorder")
                } else if (serverData == false) {
                    $("#Email-Double").css("display", "none")
                    $("#EMail").removeClass("redBorder")
                }
            })
            //diese Methode wrid aufgerufen, falls der Server/ die URL nicht erreichbar ist
            .fail(() => {
                alert("Server/ URL nicht erreichbar!")
            })
            
    })

    $("#btn-toggle").click(() => {
        $("#formReg").toggle(500)
    })
});


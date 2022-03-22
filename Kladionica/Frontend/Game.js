export class Game
{
    constructor(id,tickN,naz1,naz2,m1,m2,mx) {
        this.id=null;
        this.tickN=tickN;
        this.naz1 = naz1;
        this.naz2 =naz2;
        this.m1=m1;
        this.m2=m2;
        this.mx=mx;

    }
    kreirajIgru(host)
    {
        if(this.tickN == ""||this.naz1 == ""||this.naz2 == ""||this.m1 == ""||
        this.m2 == ""||this.mx == "")
        {
            alert("popunite sva polja");
            return;
        }

        let url = "https://localhost:5001/Game/DodajIgru/";
        
        fetch(url,{
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                TicketNumber : parseInt(this.tickN),
                ClubName1 : this.naz1,
                ClubName2 : this.naz2,
                Multiplier1 : parseFloat(this.m1),
                Multiplier2 : parseFloat(this.m2),
                MultiplierX : parseFloat(this.mx)   
            })
        }).then(response =>{
            if(response.ok ==true)
            {
                alert("uspesno kreirano");
                this.crtajIgru(host);

                //this.dodajPreviewNaFront(this.tickN);
                //UPDATE PREVIEW
            }
            else
            {
                //console.dir(response);
                alert("Imas error u unosu, proveri network/dodajIgru za vise detalja")
                //stapaj error onaj tamo $$$ ako stignes
            }
            
        });
        //.catch(err => err.text().then(errMsg => alert(errMsg)));
    }
    crtajIgru(host)
    {
        if(this.tickN == ""||this.naz1 == ""||this.naz2 == ""||this.m1 == ""||
        this.m2 == ""||this.mx == "")
        {
            return;
        }

        //host == tabela
        let red = document.createElement("tr");
        red.classList.add("redIgra");
        host.appendChild(red);

        let values = [this.tickN,this.naz1,this.naz2,this.m1,this.m2,this.mx];
        for(let i=0;i<6;i++)
        {
            let td = document.createElement("td");
            td.classList.add("tdIgra");
            td.innerHTML=values[i];
            red.appendChild(td);
        }
        let button = document.createElement("button");
        button.type="submit";
        button.onclick= (ev) => this.obrisiIgru(this.TicketNumber);//$$ pazi sta prosledis
        button.innerHTML="Obrisi";
        red.appendChild(button);
    }
    obrisiIgru(ticketNumber)
    {
        
        let url = "https://localhost:5001/Game/IzbrisiGame/" + ticketNumber;
        console.log(url,);
        fetch(url,{
            method: 'DELETE',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            }
        });

        //console.log(ticketNumber + 'je ticket number');

        // front crtanje
        var rows = document.getElementsByClassName("redIgra");
        for ( var i = 1; i < rows.length; i++ ) {
            var row = rows[i];
            let tds = row.getElementsByTagName("td"); //trenutni row

            if(tds[0].innerHTML == ticketNumber)
            {
            let  parent = row.parentNode;
                parent.removeChild(row);
            }
        }
    }
    izmeniIgru(podaci)
    {
        let url = "https://localhost:5001/Game/IzmeniIgru/";
        
        fetch(url,{
            method: "PUT",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                TicketNumber : parseInt(this.tickN),
                ClubName1 : this.naz1,
                ClubName2 : this.naz2,
                Multiplier1 : parseFloat(this.m1),
                Multiplier2 : parseFloat(this.m2),
                MultiplierX : parseFloat(this.mx)   
            })
        }).then(response =>{
            if(response.ok ==true)
            {
                alert("uspesno izmenjeno");
                this.precrtajIgru(this.tickN,this.naz1,this.naz2,this.m1,this.m2,this.mx);

                //this.dodajPreviewNaFront(this.tickN);
                //UPDATE PREVIEW
            }
            else
            {
                //console.dir(response);
                alert("Imas error u izmenama, proveri network/dodajIgru za vise detalja")
                //stapaj error onaj tamo $$$ ako stignes
            }
            
        });
    }
    precrtajIgru(ticketNumber,naz1,naz2,m1,m2,mx){

        var rows = document.getElementsByClassName("redIgra");
        for ( var i = 1; i < rows.length; i++ ) {
            var row = rows[i];
            let tds = row.getElementsByTagName("td"); //trenutni row

            if(tds[0].innerHTML == ticketNumber) // ako je ovaj red
            {
                tds[1].innerHTML=naz1;
                tds[2].innerHTML=naz2;
                tds[3].innerHTML=m1;
                tds[4].innerHTML=m2;
                tds[5].innerHTML=mx;

            }
        }
    }
}//class
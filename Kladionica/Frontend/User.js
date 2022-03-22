import { Game } from "./Game.js";
import { Ticket } from "./Ticket.js";


export class User
{
    constructor(id,jmbg,userName,userSurname,isAdmin,balance,password){
        this.id=id;
        this.jmbg = jmbg;
        this.name = userName;
        this.surname = userSurname;
        this.isAdmin=isAdmin;
        this.balance=balance;
        this.password = password;
        this.adminContainer = null; // oo
    }
    crtajAdmina(host)
    {
        this.adminContainer = document.createElement('div');
        this.adminContainer.classList.add("adminDiv");
        host.appendChild(this.adminContainer);

        let p = document.createElement('p');
        p.innerHTML = "Dobro dosli nazad admine, " + this.name;
        this.adminContainer.appendChild(p);
        //div forma za add novi, za menjanje, prikaz svih utakmica

        //div za prikaz utakmica
        let divGame = document.createElement("div");
        divGame.classList.add("userSubDiv");
        this.adminContainer.appendChild(divGame);

        let tabela = document.createElement("table");
        tabela.classList.add("tabelaIgre");
        divGame.appendChild(tabela);

        let red = document.createElement("tr");
        red.classList.add("redIgra");
        tabela.appendChild(red);

        let headers = ['Broj tiketa','Naziv kluba1','Naziv kluba2','1','2','X',''];
        for(let i=0;i<7;i++)
        {
            let th = document.createElement("th");
            th.classList.add("thIgra");
            th.innerHTML=headers[i];
            red.appendChild(th);
        }
        //vrati sve igre
        let url = "https://localhost:5001/Game/VratiIgre";
        //response = fetch(url).then(p =>{p.json().then(r => {return r})});
        
        //console.dir(response);
        fetch(url).then(p =>{
            p.json().then(data =>{
                data.forEach(igra => { // za svaku igru

                    //pravi se red
                    let red = document.createElement("tr");
                    red.classList.add("redIgra");
                    tabela.appendChild(red);
                    let tableData=[igra.ticketNumber,igra.clubName1,igra.clubName2,igra.multiplier1,igra.multiplier2,igra.multiplierX];
                    for(let i=0;i<6;i++)
                    {
                        let td = document.createElement("td");
                        td.classList.add("tdIgra");
                        td.innerHTML=tableData[i];
                        red.appendChild(td);
                    }
                    let button = document.createElement("button");
                    button.type="submit";
                    button.onclick= (ev) => this.obrisiIgru(igra.ticketNumber);//$$ pazi sta prosledis
                    button.innerHTML="Obrisi";
                    red.appendChild(button);
                });
            })
        })


        //div za dodavanje utakmica
        divGame = document.createElement("div");
        divGame.classList.add("userSubDiv");
        this.adminContainer.appendChild(divGame);

        p = document.createElement('p');
        p.innerHTML = "Kreiraj utakmicu";
        divGame.appendChild(p);

        let labele = ['Broj tiketa','Naziv kluba 1','Naziv kluba 2','Kvota 1','Kvota 2', 'Kvota X'];
        let tipovi = ['number','text','text','number','number','number']
        for(let i =0;i<6;i++)
        {//for
            let inputDiv = document.createElement('div');
            inputDiv.classList.add("userInputDiv");
            divGame.appendChild(inputDiv);

            let label = document.createElement("label");
            label.innerHTML = labele[i];
            divGame.appendChild(label);
            
            let input = document.createElement("input");
            input.type=tipovi[i];
            input.className = "gameInput"; // ovo koristim kod query selector all
            divGame.appendChild(input);
        }//for
        let button = document.createElement("button");
        button.type="submit";
        button.onclick= (ev) => this.kreirajIgru(tabela);
        button.innerHTML="Dodaj";
        divGame.appendChild(button);

        //Div za update
        //-------------
        divGame = document.createElement("div");
        divGame.classList.add("userSubDiv");
        this.adminContainer.appendChild(divGame);

        p = document.createElement('p');
        p.innerHTML = "Izmeni utakmicu";
        divGame.appendChild(p);

        labele = ['Broj tiketa','Naziv kluba 1','Naziv kluba 2','Kvota 1','Kvota 2', 'Kvota X'];
        tipovi = ['number','text','text','number','number','number']
        for(let i =0;i<6;i++)
        {//for
            let inputDiv = document.createElement('div');
            inputDiv.classList.add("userUpdateDiv");
            divGame.appendChild(inputDiv);

            let label = document.createElement("label");
            label.innerHTML = labele[i];
            divGame.appendChild(label);
            
            let input = document.createElement("input");
            input.type=tipovi[i];
            input.className = "gameUpdate"; // ovo koristim kod query selector all
            divGame.appendChild(input);
        }//for
        button = document.createElement("button");
        button.type="submit";
        button.onclick= (ev) => this.updateIgru(tabela);
        button.innerHTML="Izmeni";
        divGame.appendChild(button);
        //Div za update

        //---------------------
        //CRTAM TABELU USERS
        //---------------------
        //div forma za add novi, za menjanje, prikaz svih utakmica

        //div za prikaz utakmica
        divGame = document.createElement("div");
        divGame.classList.add("userSubDiv");
        this.adminContainer.appendChild(divGame);

        let tabelaK = document.createElement("table");
        tabelaK.classList.add("tabelaKorisnici");
        divGame.appendChild(tabelaK);

        red = document.createElement("tr");
        red.classList.add("redKorisnici");
        tabelaK.appendChild(red);

        headers = ['Jmbg','Ime','Prezime','Da li je admin','Balans'];
        for(let i=0;i<5;i++)
        {
            let th = document.createElement("th");
            th.classList.add("thKorisnik");
            th.innerHTML=headers[i];
            red.appendChild(th);
        }
        //vrati sve igre
        url = "https://localhost:5001/User/VratiKorisnike";
        //response = fetch(url).then(p =>{p.json().then(r => {return r})});
        
        //console.dir(response);
        fetch(url).then(p =>{
            p.json().then(data =>{
                data.forEach(korisnik => { // za svaku igru

                    //pravi se red
                    let red = document.createElement("tr");
                    red.classList.add("redKorisnik");
                    tabelaK.appendChild(red);
                    let tableData=[korisnik.jmbg,korisnik.userName,korisnik.userSurname,korisnik.isAdmin,korisnik.balance];
                    for(let i=0;i<5;i++)
                    {
                        let td = document.createElement("td");
                        td.classList.add("tdKorisnik");
                        td.innerHTML=tableData[i];
                        red.appendChild(td);
                    }
                    let button = document.createElement("button");
                    button.type="submit";
                    button.onclick= (ev) => this.obrisiIgru(igra.ticketNumber);//$$ pazi sta prosledis
                    button.innerHTML="Obrisi";
                    red.appendChild(button);
                });
            })
        })
        //---------------------
        //CRTAM TABELU USERS
        //---------------------
    }
    crtajKorisnika(host)
    {
        const ticket = new Ticket();
        ticket.crtajTicket(document.body);
        // sad ovo
        this.adminContainer = document.createElement('div');
        this.adminContainer.classList.add("adminDiv");
        host.appendChild(this.adminContainer);

        let p = document.createElement('p');
        p.innerHTML = "Dobro dosli nazad korisnice, " + this.name;
        this.adminContainer.appendChild(p);

        //DIV ZA TABELU TICKETS

        let divGame = document.createElement("div");
        divGame.classList.add("userSubDiv");
        this.adminContainer.appendChild(divGame);

        let tabela = document.createElement("table");
        tabela.classList.add("tabelaIgre");
        divGame.appendChild(tabela);

        let red = document.createElement("tr");
        red.classList.add("redIgra");
        tabela.appendChild(red);

        let headers = ['Vase ime','broj tikete','ulog','kvota','Moguca isplata'];
        for(let i=0;i<5;i++)
        {
            let th = document.createElement("th");
            th.classList.add("thIgra");
            th.innerHTML=headers[i];
            red.appendChild(th);
        }
        //vrati sve igre
        let url = "https://localhost:5001/Ticket/VratiSveTikete/1"; //+ nesto!
        //response = fetch(url).then(p =>{p.json().then(r => {return r})});
        
        //console.dir(response);
        fetch(url).then(p =>{
            p.json().then(data =>{
                data.forEach(igra => { // za svaku igru

                    //pravi se red
                    let red = document.createElement("tr");
                    red.classList.add("redIgra");
                    tabela.appendChild(red);
                    let tableData=[igra.ticketNumber,igra.clubName1,igra.clubName2,igra.multiplier1,igra.multiplier2,igra.multiplierX];
                    for(let i=0;i<6;i++)
                    {
                        let td = document.createElement("td");
                        td.classList.add("tdIgra");
                        td.innerHTML=tableData[i];
                        red.appendChild(td);
                    }
                    let button = document.createElement("button");
                    button.type="submit";
                    button.onclick= (ev) => this.obrisiIgru(igra.ticketNumber);//$$ pazi sta prosledis
                    button.innerHTML="Obrisi";
                    red.appendChild(button);
                });
            })
        })
        //DIV ZA TABELU TICKETS


    }
    kreirajIgru(host)
    {
        let podaci =  document.querySelectorAll(".gameInput");// imam sve podatke po redosledu
        const game = new Game('',podaci[0].value,podaci[1].value,podaci[2].value,podaci[3].value,podaci[4].value,podaci[5].value);
        game.kreirajIgru(host);
       // game.crtajIgru(host); // ovo je tabela

    }
    obrisiIgru(ticketNumber)
    {
        //console.log(ticketNumber);// ok je
        const gameEmpty = new Game();
        gameEmpty.obrisiIgru(ticketNumber);
        //obrisi display
        //obrisi iz baze pozivom fje obrisi igru iz igre.js
    }
    updateIgru(host)
    {
        let podaci =  document.querySelectorAll(".gameUpdate");// imam sve podatke po redosledu
        const game = new Game('',podaci[0].value,podaci[1].value,podaci[2].value,podaci[3].value,podaci[4].value,podaci[5].value);
        game.izmeniIgru(host);// host je tabela, ostalo se vec salje

    }
    
}
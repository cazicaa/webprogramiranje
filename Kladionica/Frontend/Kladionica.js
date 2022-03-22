import { User } from "./User.js";

export class Kladionica
{
    constructor(host)
    {
        this.crtajLogin(host);
    }
    crtajLogin(host)
    {
        let loginDiv = document.createElement('div');
        loginDiv.classList.add("loginDiv");
        host.appendChild(loginDiv);
        


        let elLabela = document.createElement('label');
        elLabela.classList.add('loginLabel');
        elLabela.innerHTML = 'JMBG';
        loginDiv.appendChild(elLabela);

        let tb = document.createElement('input');
        tb.className="usernameTB";
        tb.name="username"
        loginDiv.appendChild(tb);

        elLabela = document.createElement('label');
        elLabela.classList.add('loginLabel');
        elLabela.innerHTML = 'Password';
        loginDiv.appendChild(elLabela);

        tb = document.createElement('input');
        tb.className="passwordTB";
        tb.type ="password";
        tb.name ="password";
        loginDiv.appendChild(tb);

        let submitButton = document.createElement('button');
        submitButton.innerHTML = "Login";
        submitButton.onclick= (ev) => this.tryToLogIn(host);
        loginDiv.appendChild(submitButton);

    }
    tryToLogIn()
    {
        
        let username = document.querySelector(".usernameTB").value;
        //$$$$$$
        //username ="1234567890123";
        let pass = document.querySelector(".passwordTB").value;
        //fetchuj svi login data,proveri sa unos, ako je ok crtaj ono sto treba da se crta
        fetch("https://localhost:5001/User/VratiKorisnike").then(p =>{
        p.json().then(data =>{
                let exists= false;
                data.forEach(korisnikBaza =>{
            
                    //ovde imam svaki korisnik, sad vrsim proveru
                if(korisnikBaza.jmbg == username && korisnikBaza.password == pass) // ako je valid login data
                {
                    
                    let login = document.querySelector(".loginDiv"); // uklanjamo login
                    login.parentNode.removeChild(login);
                    exists = true;
                    this.crtajKorisnika(korisnikBaza);
                }
                });
                if(!exists) // ako je nadjen korisnik
                {
                    alert("Ovakav korisnik ne postoji. Proverite podake");
                }
            });
        });
        

        
        
    }
    crtajKorisnika(korisnik)
    {
        //sad imam korisnika i treba da ga crtam
        const user = new User(korisnik.id,korisnik.jmbg,korisnik.userName,korisnik.userSurname,korisnik.isAdmin,korisnik.balance,korisnik.password);

        if(korisnik.isAdmin == true)
            user.crtajAdmina(document.body);
        else user.crtajKorisnika(document.body);
       // lok = new Lokacija(i,j,"","",this.kapacitet);
         //       this.dodajLokaciju(lok);
           //     lok.crtajLokaciju(red);// crtamo tu lokaciju u ovaj red



        //console.log(korisnik.isAdmin +" "+ korisnik.jmbg);
    }
}
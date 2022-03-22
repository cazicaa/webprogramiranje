using Microsoft.EntityFrameworkCore; // ovo mi treba za DbContext
//ctrl+ . 

namespace Kladionica.Models
{
    public class KladionicaContext: DbContext
    {
        //kreiremo 1 njegov obj na nivou cele app i njemu moze pristupamo
        //mora imamo klase za svaku tabelu, i svaki fajl treba ucitamo u knotekst
        // u ovom slucaju lokacija i vrt

        public DbSet<Game> Games{get;set;}// template klasa tipa Vrt. set ==lista <povezujemo sa ovom klasom>
        public DbSet<Ticket> Tickets{get;set;}
        public DbSet<User> Users{get;set;} 



        public KladionicaContext(DbContextOptions options): base(options) // ovo u knostruktoru konteksta uvek mora da ima
        {
            //ovde ga povezujemo sa bazom
            //Prvo radimo podesavanja u appsettings.json (Connections strings dodajemo tamo)
        }

    }
}
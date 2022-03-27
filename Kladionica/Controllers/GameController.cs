using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kladionica.Models; // za kladionicaContext
using Microsoft.EntityFrameworkCore;

namespace Kladionica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase 
    {
        //Ovo dodajemo public context koji je iz kladionice, on ce da bude glavni odakle se vade podaci
        public KladionicaContext Context { get; set; }

        public GameController(KladionicaContext context)
        {
            Context = context;
        }
    [Route("VratiIgre")]
    [HttpGet]
    public async Task<ActionResult> VratiIgre()
    {
        try
        {
            return Ok(await Context.Games.Include(p => p.Tickets).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Route("DodajIgru")]
    [HttpPost]
    public async Task<ActionResult> DodajIgru([FromBody] Game game) // mozda ovde mozes da stavis da bude tip int, pa ako je 1 sve je ok, ako ne onda je lose u if
    {
        try
        {
            if(game.Multiplier1<=1 || game.Multiplier2<=1 ||game.MultiplierX <=1)
            throw new Exception("Lose vrednosti za kvote, previse su niske");

            foreach(Game gameX in Context.Games)
            {
                if(game.TicketNumber == gameX.TicketNumber)
                {
                    throw new Exception("Izabrani broj tiketa vec postoji");
                }
                if(game.ClubName1 == gameX.ClubName1 && game.ClubName2 == game.ClubName2)
                {
                    throw new Exception("Tiket sa ovim klubovima je vec kreiran");
                }
            }

            Context.Games.Add(game); // lokalno u app dodajem game
            return Ok(await Context.SaveChangesAsync()); // Ako je ovo 1 vraca nam Task<ActionResult> i sve je uredu //$_$ok,badrewquest,statuscode za astuion result

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);// vraca string
        }
        
        
    }
    //ud
    [Route("IzmeniIgru")]
    [HttpPut] // to je kao post samo updatujes
    public async Task<ActionResult> IzmeniIgru([FromBody] Game game)// podatke koji su poslati preko forme dodaje u game ako imaju ista imena
    {
        //
        try
        {
            if(game.Multiplier1<=1 || game.Multiplier2<=1 ||game.MultiplierX <=1)
            throw new Exception("Lose vrednosti za kvote, previse su niske");

            //game.ID = ID;
            bool prosaoKrozMenjani= false;
            foreach(Game gameX in Context.Games)
            {   
                if(gameX.TicketNumber == game.TicketNumber) // ovaj treba da se menja 
                {
                    prosaoKrozMenjani=true;
                    gameX.ClubName1=game.ClubName1;
                    gameX.ClubName2=game.ClubName2;
                    gameX.Multiplier1=game.Multiplier1;
                    gameX.Multiplier2=game.Multiplier2;
                    gameX.MultiplierX=game.MultiplierX;
                   // game
                   // prosaoKrozMenjani = true;
                   // if(game.TicketNumber != gameX.TicketNumber)
                   //     throw new Exception("Ticket number ne sme da se menja!");
                    continue;
                } 
               // else if(game.ClubName1 == gameX.ClubName1 && game.ClubName2 == gameX.ClubName2 && prosaoKrozMenjani ==true)
              //  {
                   // throw new Exception("Tiket sa ovim klubovima je vec kreiran");
               // }
            }
            if(prosaoKrozMenjani == true)
            {
               // Context.Games.Update(gameX)
                //Context.Game.Update(gameX); // lokalno u app dodajem game
            return Ok(await Context.SaveChangesAsync()); // Ako je ovo 1 vraca nam Task<ActionResult> i sve je u redu
            }
            else throw new Exception("Ovaj tiket ne postoji");
            

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        //
    }

        [Route("IzbrisiGame/{TicketNumber}")]
        [HttpDelete]
        public async Task<ActionResult>  IzbrisiGame(int TicketNumber)
        {
            try
            {
                var game = await Context.Games.Where(gameX => gameX.TicketNumber == TicketNumber).FirstOrDefaultAsync();
                if (game == null)
                    return BadRequest("Ne postoji film u bioskopu.");
                Context.Games.Remove(game);
                return Ok(await Context.SaveChangesAsync()); //update bazu
                //await Context.SaveChangesAsync();
                //return Ok("Uspesno izbrisana igra");
            }
            catch(Exception e)
            {
            return BadRequest(e.Message); 
            }


            
        //         var games = await Context.Games.Where(game => game.TicketNumber == TicketNumber).ToListAsync();
        //         foreach(Game game in games)
        //         {
                    
        //        // if(game != null)
        //      //   throw new Exception("Ova igra NE postoji :P");
        //         Context.Remove(game);//brise game iz lokalne kopije baze
        //         return Ok(await Context.SaveChangesAsync()); //update bazu
        //         }
        //         Context.Remove(games);
                 

        //        // }
        //        // //var game = await Context.Games.FindAsync(TicketNumber); //nalazi game sa ovim id-jem, || MORA AWAIT ZBOG ASYNC
            
       
            
            
        }

    //

    }//class
}//namespace
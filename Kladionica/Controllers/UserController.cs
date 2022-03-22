using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kladionica.Models; // za kladionica models
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // za .Include
using Microsoft.Extensions.Logging;
using Kladionica.Controllers;

namespace Kladionica.Controllers // $ovo cu da unsing u dugim kontrolerima, ili ne hehe
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //Ovo dodajemo public context koji je iz kladionice, on ce da bude glavni odakle se vade podaci
        public KladionicaContext Context { get; set; }

        public UserController(KladionicaContext context)
        {
            Context = context;
        }

        //
        [Route("VratiKorisnike")]
        [HttpGet]
        public async Task<ActionResult> VratiKorisnike()
        {
            try
            {
                return Ok(await Context.Users.Include(p => p.Tickets).ToListAsync());
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
                
            }
        }

        [Route("DodajKorisnika")]
        [HttpPost]
        public async Task DodajKorisnika([FromBody] User user) //ovde moze i from 
        {
            //$$ proveri za jmbg da li je unique
            Context.Users.Add(user); // lokalno u app dodajem vrt
            await Context.SaveChangesAsync(); // E ovde se cuvaju promene i mora async
            //$$ Kad upisujes preko swaggera, nikad id ne upisujes, on sam to radi
        }
        
        //
    }

}
/*
moze dodas i brisi korisnika, admin moze da brise obicne korisnike
*/
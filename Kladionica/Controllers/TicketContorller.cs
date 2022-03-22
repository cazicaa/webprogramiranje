using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kladionica.Models; // za kladionica models
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // za .Include
using Microsoft.Extensions.Logging;
using Kladionica.Controllers;

namespace Kladionica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase 
    {
        public KladionicaContext Context { get; set; }

        public TicketController(KladionicaContext context)
        {
            Context = context;
        }

        [Route("VratiSveTikete/{userId}")]
        [HttpGet]
        public async Task<ActionResult> VratiTikete(int userId)
        {
            try
            {
                return Ok(await Context.Tickets.Include(ticket => ticket.UserId).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajTiket/{userId}")]
        [HttpPost]
        public async Task<ActionResult> DodajTiket(int userId,[FromBody] Ticket ticket)
        {
            try
            {
                ticket.UserId = userId;
                Context.Tickets.Add(ticket); // lokalno u app dodajem game
                return Ok(await Context.SaveChangesAsync()); // Ako je ovo 1 vraca nam Task<ActionResult> i sve je uredu
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }



    }//class
}//namespace
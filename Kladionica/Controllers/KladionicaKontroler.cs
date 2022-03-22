using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kladionica.Models; // za kladionica models
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // za .Include
using Microsoft.Extensions.Logging;


namespace Kladionica.Controllers // $ovo cu da unsing u dugim kontrolerima, ili ne hehe
{
    [ApiController]
    [Route("[controller]")]
    public class KladionicaController : ControllerBase
    {
        public KladionicaContext Context { get; set; } // Atribut koji cuva kontekst kladionice, sto znaci cele baze 

        public KladionicaController(KladionicaContext context)
        {
            Context = context; // kad se napravi kontroler, ubaci mu se proslenjeni context
        }
    

        //
        
        //
    }

}

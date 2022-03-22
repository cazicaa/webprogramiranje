using System.Collections.Generic;// za list
using System.ComponentModel.DataAnnotations; // za key
using System.ComponentModel.DataAnnotations.Schema; // za [] atribute
using Kladionica.Models;
namespace Kladionica.Models
{
    //atributi
    [Table("Games")] // ime tabele Games
    public class Game
    {
        [Key] // ozanacavamo da je ovo primary key
        [Column("ID")]
        public int ID{get;set;}

        [Required]
        [Column("TicketNumber")]
        public int TicketNumber { get; set; }

        [Required]
        [Column("ClubName1")]
        public string ClubName1 { get; set; }

        [Required]
        [Column("ClubName2")]
        public string ClubName2 { get; set; }

        [Required]
        [Column("Multiplier1")]
        public double Multiplier1 { get; set; }
        [Required]
        [Column("Multiplier2")]
        public double Multiplier2 { get; set; }
        [Required]
        [Column("MultiplierX")]
        public double MultiplierX { get; set; }
        

        public virtual List<Ticket> Tickets { get; set; } // 1 game ima vise tiketa

        //Kako bilo koja fja da se napise
        
    }
}
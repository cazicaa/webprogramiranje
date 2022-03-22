using System.Collections.Generic;// za list
using System.ComponentModel.DataAnnotations; // za key
using System.ComponentModel.DataAnnotations.Schema; // za [] atribute
using System.Text.Json.Serialization; // za [JsonIgnore]

namespace Kladionica.Models
{
    //atributi
    [Table("Tickets")] // ime tabele
    public class Ticket
    {
        [Key] // ozanacavamo da je ovo primary key
        [Column("ID")]
        public int ID{get;set;}

        [Required]
        [Column("TicketNumber")] // ovo uzimam od game
        public int TicketNumber { get; set; }

        [Required]
        [Column("Stake")] // ulog unosim iz js-a
        public double Stake { get; set; }

        [Required]
        [Column("Multiplier")]
        public double Multiplier { get; set; }

        [Required]
        [Column("Payout")]
        public double Payout { get; set; }
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        [Column("ChosenClubName")]
        
        [JsonIgnore]
        public virtual List<Game> Game { get; set; } // Jedan tiket ima 1 game

        [JsonIgnore]
        public virtual List<User> User { get; set; } // Jedan tiket ima 1 user-a


        
    }
}
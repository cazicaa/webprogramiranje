using System.Collections.Generic;// za list
using System.ComponentModel.DataAnnotations; // za key
using System.ComponentModel.DataAnnotations.Schema; // za [] atribute

namespace Kladionica.Models
{
    //atributi
    [Table("Users")] // ime tabele Games
    public class User
    {
        [Key] // ozanacavamo da je ovo primary key
        [Column("ID")]
        public int ID{get;set;}

        [Required]
        [Column("JMBG")]
        public string JMBG { get; set; }

        [Required]
        [Column("UserName")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [Column("UserSurname")]
        [MaxLength(50)]
        public string UserSurname { get; set; }

        [Required]
        [Column("IsAdmin")]
        public bool IsAdmin { get; set; }
        [Required]
        [Column("Balance")]
        [Range(0,1000000)]
        public double Balance { get; set; }
        
        [Required]
        [Column("Password")]
        public string Password { get; set; }

        public virtual List<Ticket> Tickets { get; set; } // 1 User moze da ima vise tiketa

        
    }
}
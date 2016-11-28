using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adressbok.Models
{
    public class Person
    {

        public Guid PersonId { get; set; }

        [Required(ErrorMessage ="Fyll i ditt namn")]
        public string Namn { get; set; }
        [Required(ErrorMessage ="Fyll i adress")]
        public string Adress { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Nummer")]
        [Required(ErrorMessage = "Telefon nummer Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon nummrets format är inte giltigt.")]
        public string TelefonNr { get; set; }

        public DateTime AdressÄndring { get; set; }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTutorial.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }

    }
}
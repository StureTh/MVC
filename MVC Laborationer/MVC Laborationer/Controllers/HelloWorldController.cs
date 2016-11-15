using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Laborationer.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "This is my <b>default</b> action..";
        }

        public string Welcome(string name, int numtimes = 1)
        {
            
            return HttpUtility.HtmlEncode($"Hello {name}\n Numtimes is: {numtimes}");
        }
    }
}
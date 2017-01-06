using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adressbok.Models;

namespace Adressbok.Controllers
{
    public class AdressbokController : Controller
    {
        public static List<Person> PersonLista = new List<Person>();
        // GET: Adressbok
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LäggTillPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LäggTillPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                person.PersonId = Guid.NewGuid();
                person.AdressÄndring = DateTime.Now;
               
                PersonLista.Add(person);

                return PartialView("LäggTillPerson");
            }
            else
            {
                return PartialView("LäggTillPerson",person);
            }
        }

        public ActionResult VisaAdressBok()
        {
            return PartialView(PersonLista);
        }

        public ActionResult Edit(Guid id)
        {
            var personToEdit = PersonLista.Find(p => p.PersonId == id);

            return View(personToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {

            var personToEdit = PersonLista.Find(x => x.PersonId == person.PersonId);
            
            personToEdit.Namn = person.Namn;
            personToEdit.Adress = person.Adress;
            personToEdit.AdressÄndring = DateTime.Now;
            personToEdit.TelefonNr = person.TelefonNr;
            
            return RedirectToAction("VisaAdressBok");

        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var personToRemove = PersonLista.Find(x => x.PersonId == id);

            PersonLista.Remove(personToRemove);

            return PartialView("VisaAdressBok",PersonLista);
            
        }
    }
}
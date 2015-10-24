using ASPNETMVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();                          
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }          
        
        public ActionResult ListOfPeople()
        {
            var people = new List<string>()
            {
                "Mark Zuckerberg",
                "Bill Gates",
                "Steve Jobs"
            };

            return this.View(people);
        }                     
        
        public JsonResult Details(int id)
        {
            var details = new List<object>()
            {
                new {
                    imageUrl = "http://a4.files.biography.com/image/upload/c_fill,cs_srgb,dpr_1.0,g_face,h_300,q_80,w_300/MTIwNjA4NjMzNjg3ODAzNDA0.jpg",
                    address = "1456 Edgewood Dr, Palo Alto, CA 94301",
                    contact = "2323232323",
                    email = "mark@facebook.com",
                    status = "Married",
                    age = 28
                },
                new {
                    imageUrl = "http://images.boomsbeat.com/data/images/full/595/bill-gates-jpg.jpg",
                    address = "a",
                    contact = "1",
                    email = "b@c.d",
                    status = "e",
                    age = 2
                },
                new {
                    imageUrl = "http://mammothtimes.com/sites/default/files/field/image/SteveJobs2.jpg",
                    address = "f",
                    contact = "3",
                    email = "g@h.i",
                    status = "j",
                    age = 4
                }
            };

            return Json(details[id], JsonRequestBehavior.AllowGet);
        }            

        public ActionResult Autocomplete()
        {
            return this.View();
        }

        public JsonResult AutocompleteResult(string town)
        {
            var townNames = new List<string>()
            {
                "Ankara",
                "Aalborg",
                "Albacete",
                "Amsterdam",
                "Buenos Aires",
                "Burgas",
                "Bobov dol",
                "Birmingham",
                "Cagliari",
                "Cairo",
                "Cambridge",
                "Cologne",
                "Delhi",
                "Derby",
                "Dublin",
                "Dortmund",
                "Eastbourne",
                "Ebetsu",
                "Ebina",
                "Ecatepec",
                "Faisalabad",
                "Faizabad",
                "Faridabad",
                "Farrukhabad",
                "Gabes",
                "Gaborone",
                "Gadag-Betgeri",
                "Galati",
                "Ha Long",
                "Haarlem",
                "Habikino",
                "Habra",
                "Iasi",
                "Ibadan",
                "Ibague",
                "Ibaraki",
                "Jabalpur",
                "Jacarei",
                "Jackson",
                "Jacksonville",
                "Kabul",
                "Kadoma",
                "Kaduma",
                "Kailli",
                "London",
                "La plata",
                "Lagos",
                "Le Mans",
                "Manchester",
                "Munich",
                "Macau",
                "Madrid",
                "Naples",
                "Nara",
                "Norwich",
                "Novara",
                "Oakland",
                "Oakville",
                "Obersdorf",
                "Odessa",
                "Pleven",
                "Plovdiv",
                "Paderborn",
                "Preston",
                "Quebec",
                "Qom",
                "Qidong",
                "Quanzhou",
                "Rabat",
                "Radom",
                "Rajkot",
                "Raichur",
                "Stockholm",
                "Sofia",
                "Stoke",
                "Samara",
                "Tabriz",
                "Tacna",
                "Tallin",
                "Taraz",
                "Ube",
                "Uberaba",
                "Ufa",
                "Uji",
                "Valencia",
                "Valdivia",
                "Valladolid",
                "Valledupar",
                "Waco",
                "Wadhwan",
                "Walsall",
                "Wardha",
                "Xalapa",
                "Xiamen",
                "Xian",
                "Xiantao",
                "Yachiyo",
                "Yakeshi",
                "Yakutsk",
                "Yemen",
                "Zaanstad",
                "Zabol",
                "Zama",
                "Zagreb"
            };

            if (town.Length == 1)
            {
                town = town.ToUpper();
            }

            var data = townNames.Where(tn => tn.StartsWith(town));

            return Json(new { towns = data }, JsonRequestBehavior.AllowGet);
        }
    }
}
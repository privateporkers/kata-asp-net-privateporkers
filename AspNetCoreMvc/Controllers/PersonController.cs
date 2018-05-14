using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.Controllers
{
    public class PersonController : Controller
    {
       public IActionResult Index()
       {
           var people = new List<Person>
           {
           new Person() {Name = "David"},
           new Person() {Name = "John"},
           new Person() {Name = "Dylan"},
           new Person() {Name = "Daniel"},
           new Person() {Name = "Brandon"},
           new Person() {Name = "Cody"},
           };

           return View(people);
       } 

       public IActionResult Edit()
       {
           return View();
       }
    }
}
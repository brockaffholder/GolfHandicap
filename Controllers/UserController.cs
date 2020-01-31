using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolfHandicap.ViewModels;
using Microsoft.AspNetCore.Http;
using GolfHandicap.Data;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicap.Controllers
{
    public class UserController : Controller
    {
        private RoundDbContext context;
        public UserController(RoundDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            //var ScoreDiffss= context.Rounds.ToList();
            var ScoreDiffs = context.Rounds.Select(r => r.ScoreDifferential).ToList();
            float HandicapIndex = ScoreDiffs.Average();

            ViewBag.Handicap = HandicapIndex;
           
            return View();
        }


        // GET: /<controller>/
        public IActionResult TIndex()
        {
            //linq query to go here for pulling specific ************ QUERY FOR FINAL PART CALC OF HANDICAP INDEX
            //var HandicapIndex = (from h in GolfHandicap select h.ScoreDifferential).Average();

            return View();
        }













        // GET: /<controller>/

        // GET  /User/Add
        /*public IActionResult Add()
        {
            AddUserViewModel vm = new AddUserViewModel();
            return View();
        }

        //POST /User/Add
        [HttpPost]
        public IActionResult Add(AddUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                //create user in DB
                GolfHandicap.Models.User user = new GolfHandicap.Models.User();
                user.CreateUser(newUser);
                //set user cookie
                Response.Cookies.Append("user", user.ID.ToString());

                return Redirect("/User/Index?username=" +newUser.Username);
            }

            return View(newUser);
        }*/

    }
            
}

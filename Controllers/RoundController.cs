using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using System.Web;
using GolfHandicap.Data;
using GolfHandicap.Models;
using GolfHandicap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GolfHandicap.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicap.Controllers
{
    public class RoundController : Controller
    {
        private RoundDbContext Context;

        private IAuthorizationService AuthorizationService { get; }
        private UserManager<IdentityUser> UserManager { get; }

        public RoundController(RoundDbContext dbContext, IAuthorizationService authorizationService,
                            UserManager<IdentityUser> userManager) : base()
        {
            Context = dbContext;
            AuthorizationService = authorizationService;
            UserManager = userManager;
        }

        //public GolfHandicap.Models.User User;

        /*public RoundController(RoundDbContext dbcontext, IHttpContextAccessor httpContextAccessor)
        {
            //string userCookie = Request.Cookies["user"];
            string userCookie = httpContextAccessor.HttpContext.Request.Cookies["user"];

            if (userCookie == null)
            {
                //redirec to home
                Redirect("/");
            }
            else
            {
                Context = dbcontext;
                //get user some DB and set user values:
                //User.SetValues(userCookie);
            }*/

    

    // GET: /<controller>/
    public IActionResult Index()
        {
            //List<Round> rounds = Context.Rounds.ToList();
            //return View(rounds);
            var rounds = from r in Context.Rounds
                          select r;

            var isAdminAuthorized = User.IsInRole(Constants.AdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAdminAuthorized)
            {
                rounds = rounds.Where(c => c.UserID == currentUserId);
            }

            return View(rounds.ToList());

        }
        /*[HttpGet]
        public ActionResult Round()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Round(Round round)
        {
            round.ScoreDifferential = (round.Score - round.Rating) * 113 / round.Slope;
            ViewData["Round"] = round.ScoreDifferential;
            return View(round);
        }*/

        public IActionResult Add()
        {
            AddRoundViewModel addRoundViewModel = new AddRoundViewModel();

            return View(addRoundViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoundViewModel addRoundViewModel)
        {
            if (ModelState.IsValid)
            {
                //adding a new round to my existing rounds (***up to 20 rounds***)
                //add in calculation for score differential here then ill be able to add to database in the below add and save

                float ScoreDifferential = (addRoundViewModel.Score - addRoundViewModel.Rating)
                    * 113 / addRoundViewModel.Slope;
                
                //Round to two decimal places for ending score differential
                ScoreDifferential.ToString("n2");

                Round newRound = new Round
                {
                    Course = addRoundViewModel.Course,
                    Score = addRoundViewModel.Score,
                    Slope = addRoundViewModel.Slope,
                    Rating = addRoundViewModel.Rating,
                    ScoreDifferential = ScoreDifferential,
                    UserID = UserManager.GetUserId(User)
                };

                var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                    User, newRound,
                                                    RoundOperations.Create);

                if (!isAuthorized.Succeeded)
                {
                    return Forbid();
                }

                Context.Rounds.Add(newRound);
                await Context.SaveChangesAsync();

                return Redirect("/Round");
            }

            return View(addRoundViewModel);
        }

    }
}
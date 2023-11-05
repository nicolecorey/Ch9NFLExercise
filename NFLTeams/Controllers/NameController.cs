using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {

            [HttpGet]
            public ViewResult Index()
            {
                // get favorite teams and current conference and division
                // from session, pass to view in view model
                var session = new NFLSession(HttpContext.Session);
                var model = new TeamsViewModel
                {

                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv(),
                    Teams = session.GetMyTeams(),
                    UserName = session.GetName()
                };

                return View(model);
            }
        [HttpPost]
        public RedirectToActionResult Change(TeamsViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetName(model.UserName);

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }
    }
}

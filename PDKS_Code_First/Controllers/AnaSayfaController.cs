using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDKS_Code_First.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
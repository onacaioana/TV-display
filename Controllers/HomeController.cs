using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebSalt.Models;
using WebSalt.SqlServerNotifier;

namespace WebSalt.Controllers
{

    public class HomeController : Controller
    {
        private HotarariContext db = new HotarariContext();
        // GET: Home

        public async Task<ActionResult> Index()
        {
           
            String sala = System.Configuration.ConfigurationManager.AppSettings["Sala"].ToString();
            var collection = db.Hotarari.Where(p => p.complet_activ_sedinta == 1
                                                   && p.data_sedinta.Day == DateTime.Now.Day
                                                   && p.data_sedinta.Month == DateTime.Now.Month
                                                   && p.data_sedinta.Year == DateTime.Now.Year
                                                   && p.sala_sedinta == sala).OrderBy(p => p.nr_ordine_text);
            ViewBag.NotifierEntity = db.GetNotifierEntity<Hotarari>(db.Hotarari).ToJson();
            if (collection.Count() == 0)
                return View("Empty");

            String completuriStr = String.Empty;
            foreach (var item in collection.Select(x => x.completul).Distinct())
            {
                completuriStr += item.ToString() + ";";
            }

            String sectiaStr = collection.First().sectia;

            ViewBag.sectia = sectiaStr;
            ViewBag.completuri = completuriStr;
            ViewBag.size = collection.Count() * 39;
            var setari = collection.Where(p => p.complet_suspendat_sedinta == 1).Select(x => x.interval_orar_suspendare);
            if (setari.Count() > 0)
            {
                ViewBag.interval = setari.FirstOrDefault();
                return View("Suspendare");
            }
            
            return View(await collection.ToListAsync());
        }

        public async Task<ActionResult> IndexPartial()
        {
            String sala = System.Configuration.ConfigurationManager.AppSettings["Sala"].ToString();
            var collection = db.Hotarari.Where(p => p.complet_activ_sedinta == 1
                                                   && p.data_sedinta.Day == DateTime.Now.Day
                                                   && p.data_sedinta.Month == DateTime.Now.Month
                                                   && p.data_sedinta.Year == DateTime.Now.Year
                                                   && p.sala_sedinta == sala).OrderBy(p => p.nr_ordine_text);

            ViewBag.NotifierEntity = db.GetNotifierEntity<Hotarari>(db.Hotarari).ToJson();
            if (collection.Any())
                ViewBag.interval = collection.First().interval_orar_suspendare;
            return PartialView(await collection.ToListAsync());
        }

        public ActionResult Refresh(int? id)
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
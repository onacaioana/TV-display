using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebSalt.Controllers
{
    public class HotararisController : Controller
    {
        private salaTestEntities2 db = new salaTestEntities2();

        // GET: Hotararis
        public ActionResult Index(int? page)
        {

            var sala = System.Configuration.ConfigurationManager.AppSettings["Sala"];
            var products = db.Hotararis.Where(p => p.complet_activ_sedinta == 1
                                                && p.sala_sedinta == sala
                                                && p.data_sedinta.Day == DateTime.Now.Day
                                                && p.data_sedinta.Month == DateTime.Now.Month
                                                && p.data_sedinta.Year == DateTime.Now.Year).OrderBy(p => p.nr_ordine);


            int pageSize = 22;
            int pageNumber = (page ?? 1);
            var onePageOfProducts = products.ToPagedList(pageNumber, pageSize); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        // GET: Hotararis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotarari hotarari = db.Hotararis.Find(id);
            if (hotarari == null)
            {
                return HttpNotFound();
            }
            return View(hotarari);
        }

        // GET: Hotararis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotararis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sectia,completul,nr_ordine,numar_national,obiect_dosar,stadiu_procesual,parti,status_sedinta,sala_sedinta,data_sedinta,ora_complet,termen_acordat,pronuntare_sedinta,obiect_sedinta,complet_activ_sedinta,complet_suspendat_sedinta,interval_orar_suspendare")] Hotarari hotarari)
        {
            if (ModelState.IsValid)
            {
                db.Hotararis.Add(hotarari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotarari);
        }

        // GET: Hotararis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotarari hotarari = db.Hotararis.Find(id);
            if (hotarari == null)
            {
                return HttpNotFound();
            }
            return View(hotarari);
        }

        // POST: Hotararis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sectia,completul,nr_ordine,numar_national,obiect_dosar,stadiu_procesual,parti,status_sedinta,sala_sedinta,data_sedinta,ora_complet,termen_acordat,pronuntare_sedinta,obiect_sedinta,complet_activ_sedinta,complet_suspendat_sedinta,interval_orar_suspendare")] Hotarari hotarari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotarari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotarari);
        }

        // GET: Hotararis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotarari hotarari = db.Hotararis.Find(id);
            if (hotarari == null)
            {
                return HttpNotFound();
            }
            return View(hotarari);
        }

        // POST: Hotararis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotarari hotarari = db.Hotararis.Find(id);
            db.Hotararis.Remove(hotarari);
            db.SaveChanges();
            return RedirectToAction("Index");
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

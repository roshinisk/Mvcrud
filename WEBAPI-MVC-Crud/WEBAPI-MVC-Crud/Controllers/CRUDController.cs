using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPI_MVC_Crud.Models;
using System.Net.Http;

namespace WEBAPI_MVC_Crud.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            IEnumerable<RegionLocationUnitsAll> regobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44356/api/RegionCrud");

            var consumeapi = hc.GetAsync("RegionCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<RegionLocationUnitsAll>>();
                displaydata.Wait();

                regobj = displaydata.Result;
            }
            return View(regobj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegionLocationUnitsAll insertreg)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44356/api/RegionCrud");

            var insertrecord = hc.PostAsJsonAsync<RegionLocationUnitsAll>("RegionCrud", insertreg);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

       

        public ActionResult Edit(int id)
        {
            RegionClass regobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44356/api/RegionCrud");

            var consumeapi = hc.GetAsync("RegionCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<RegionClass>();
                displaydata.Wait();
                regobj = displaydata.Result;
            }
            return View(regobj);

        }
        [HttpPost]
        public ActionResult Edit(RegionClass rc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44356/api/RegionCrud");

            var insertrecord = hc.PutAsJsonAsync<RegionClass>("RegionCrud", rc);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = " Record Not Updated ";
            }
            return View("ec");
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44356/api/RegionCrud");
            var delrecord = hc.DeleteAsync("RegionCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        private string create( string Region, string Location, string Unit)
        {
            //guid generation
            String RowNumber = Guid.NewGuid().ToString();
            //To-Do save it into storag
            return RowNumber;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_MVC_Crud.Models;

namespace WEBAPI_MVC_Crud.Controllers
{
    public class RegionCrudController : ApiController
    {
        iSurveyEntities im = new iSurveyEntities();
        public IHttpActionResult getreg()
        {
            var results = im.RegionLocationUnitsAlls.ToList();
            return Ok(results);
        }

        [HttpPost]
        public IHttpActionResult reginsert(RegionLocationUnitsAll reginsert)
        {
            im.RegionLocationUnitsAlls.Add(reginsert);
            im.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetRowNumber(int id)
        {
            RegionClass regdetails = null;
            regdetails = im.RegionLocationUnitsAlls.Where(x => x.RowNumber == id).Select(x => new RegionClass()
            {
                RowNumber = x.RowNumber,
                Region = x.Region,
                Location = x.Location,
                Unit = x.Unit,
            }).FirstOrDefault<RegionClass>();
            if (regdetails == null)
            {
                return NotFound();
            }
            return Ok(regdetails);
        }
       

        public IHttpActionResult Put(RegionClass rc)
        {
            var updatereg = im.RegionLocationUnitsAlls.Where(x => x.RowNumber == rc.RowNumber).FirstOrDefault<RegionLocationUnitsAll>();
            if (updatereg != null)
            {
                updatereg.RowNumber = rc.RowNumber;
                updatereg.Region = rc.Region;
                updatereg.Location = rc.Location;
                updatereg.Unit = rc.Unit;
                im.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var regdel = im.RegionLocationUnitsAlls.Where(x => x.RowNumber == id).FirstOrDefault();
            im.Entry(regdel).State = System.Data.Entity.EntityState.Deleted;
            im.SaveChanges();
            return Ok();
        }

    }
}

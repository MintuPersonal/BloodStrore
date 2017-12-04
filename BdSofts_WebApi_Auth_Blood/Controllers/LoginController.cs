using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BdSofts_WebApi_Auth_Blood.Models;

namespace BdSofts_WebApi_Auth_Blood.Controllers
{
    public class LoginController : ApiController
    {
        private BdSofts_WebApi_Auth_Blood_DBEntities db = new BdSofts_WebApi_Auth_Blood_DBEntities();

        // GET: api/Login
        public IQueryable<Blood_UserInfo> GetBlood_UserInfo()
        {
            return db.Blood_UserInfo;
        }

        // GET: api/Login/5
        //[ResponseType(typeof(Blood_UserInfo))]
        //public IHttpActionResult GetBlood_UserInfo(int id)
        //{
        //    Blood_UserInfo blood_UserInfo = db.Blood_UserInfo.Find(id);
        //    if (blood_UserInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(blood_UserInfo);
        //}

        // GET: api/Login/5
        [ResponseType(typeof(Blood_UserInfo))]
        public IHttpActionResult GetBlood_UserInfo(string id, string pass)
        {
            try
            {
                var data = db.Blood_UserInfo.Where(x => x.Name.Trim() == id.Trim() && x.Pass.Trim() == pass.Trim()).FirstOrDefault();
                Blood_UserInfo blood_UserInfo = db.Blood_UserInfo.Find(data.Id);
                if (blood_UserInfo == null)
                {
                    return NotFound();
                }
                return Ok(new Blood_UserInfo { Name = "Ture" });
            }
            catch (Exception ex)
            {
                return Ok(new Blood_UserInfo { Name = "False" });
            }
           
        }

        // PUT: api/Login/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlood_UserInfo(int id, Blood_UserInfo blood_UserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blood_UserInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(blood_UserInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Blood_UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Login
        [ResponseType(typeof(Blood_UserInfo))]
        public IHttpActionResult PostBlood_UserInfo(Blood_UserInfo blood_UserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //db.Blood_UserInfo.Add(blood_UserInfo);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = blood_UserInfo.Id }, blood_UserInfo);
        }

        // DELETE: api/Login/5
        [ResponseType(typeof(Blood_UserInfo))]
        public IHttpActionResult DeleteBlood_UserInfo(int id)
        {
            Blood_UserInfo blood_UserInfo = db.Blood_UserInfo.Find(id);
            if (blood_UserInfo == null)
            {
                return NotFound();
            }

            db.Blood_UserInfo.Remove(blood_UserInfo);
            db.SaveChanges();

            return Ok(blood_UserInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Blood_UserInfoExists(int id)
        {
            return db.Blood_UserInfo.Count(e => e.Id == id) > 0;
        }
    }
}
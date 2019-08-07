using NotDefterim.Model;
using NotDefterim.Model.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace NotDefterim.Api.Controllers
{
    public class NotlarController : ApiController
    {
        public List<Not> Get(int kategoriid)
        {
            try
            {
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
                var userid = int.Parse(claimsIdentity.Claims.ToList()[2].Value);
                using (var db = new Veritabanim())
                {
                    var data = db.Not.Where(x => x.KategoriID == kategoriid && x.KullaniciID == userid).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public string Post([FromBody] Not entity)
        {
            try
            {
            //    NotDto entity = new NotDto();
            //    entity.KategoriID = entity2.KategoriID;
            //    entity.Baslik = entity2.Baslik;
            //    entity.icerik = entity2.icerik;

                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
                var userid = int.Parse(claimsIdentity.Claims.ToList()[2].Value);
                using (var db = new Veritabanim())
                {
                    entity.KullaniciID = userid;
                    db.Not.Add(entity);
                    db.SaveChanges();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

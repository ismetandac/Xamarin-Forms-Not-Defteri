using NotDefterim.Api.Models;
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
    public class KategoriController : ApiController
    {
        public List<KategoriDTO> Get()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = int.Parse(claimsIdentity.Claims.ToList()[2].Value);
            using (var db = new Veritabanim())
            {
                var kats = (from x in db.Kategori.Where(x => x.KullaniciID == userid)
                            select new KategoriDTO
                            {
                                ID = x.ID,
                                AD = x.AD,
                                KullaniciID = x.KullaniciID
                            }).ToList();

                return kats;
            }
        }
        [HttpPost]
        public bool post([FromBody]string name)
        {
            try
            {
                if (name == null)
                {
                    return false;

                }
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
                var userid = int.Parse(claimsIdentity.Claims.ToList()[2].Value);
                Kategori yenikategori = new Kategori();
                yenikategori.AD = name;
                yenikategori.KullaniciID = userid;
                using (var db = new Veritabanim())
                {
                    db.Kategori.Add(yenikategori);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

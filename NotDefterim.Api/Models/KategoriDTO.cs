using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotDefterim.Api.Models
{
    public class KategoriLst
    {
        public List<KategoriDTO> lst { get; set; }
    }
    public class KategoriDTO
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public int KullaniciID { get; set; }
    }
}
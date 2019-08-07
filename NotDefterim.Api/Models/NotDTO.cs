using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotDefterim.Api.Models
{
    [Serializable]
    public class NotDTO
    {
        public string Baslik { get; set; }
        public string icerik { get; set; }
        public int KategoriID { get; set; }
    }
}
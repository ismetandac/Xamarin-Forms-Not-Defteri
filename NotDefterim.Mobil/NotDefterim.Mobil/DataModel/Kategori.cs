using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace NotDefterim.Mobil.DataModel
{
    public partial class Kategori
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("AD")]
        public string Ad { get; set; }

        [JsonProperty("KullaniciID")]
        public int KullaniciId { get; set; }
    }
}

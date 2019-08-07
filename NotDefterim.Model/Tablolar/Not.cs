using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefterim.Model.Tablolar
{
    public class Not
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string icerik { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public Kategori Kategori { get; set; }
    }
}

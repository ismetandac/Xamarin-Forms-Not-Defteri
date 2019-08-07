using NotDefterim.Mobil.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefterim.Mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notlar : ContentPage
    {
        public int KategorID { get; set; }
        public Notlar(int _id)
        {
            KategorID = _id;
            InitializeComponent();
            getdata();
        }
        public void getdata()
        {
            var token = Application.Current.Properties["token"].ToString();
            var data = BenimServisim.Getir<ObservableCollection<NotModel>>("api/notlar?kategoriid=" + KategorID, token);
            lstNotlar.ItemsSource = data;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var token = Application.Current.Properties["token"].ToString();
            var data = new Dictionary<string, string>();
            data.Add("KategoriID", KategorID.ToString());
            data.Add("Baslik", txtBaslik.Text);
            data.Add("icerik", txtIcerik.Text);
            BenimServisim.Gonder2<Kategori>("api/notlar", data,token);
            getdata();
        }
    }
}
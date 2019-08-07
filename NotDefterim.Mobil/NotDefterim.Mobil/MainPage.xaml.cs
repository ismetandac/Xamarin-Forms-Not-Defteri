using NotDefterim.Mobil.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotDefterim.Mobil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            getdata();
        }
        public void getdata()
        {

            var token = Application.Current.Properties["token"].ToString();
            var data = BenimServisim.Getir<ObservableCollection<Kategori>>("api/kategori", token);
            lstkategori.ItemsSource = data;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var ID = ((MenuItem)sender).CommandParameter.ToString();
            Navigation.PushModalAsync(new Notlar(int.Parse(ID)));
        }
    }
}

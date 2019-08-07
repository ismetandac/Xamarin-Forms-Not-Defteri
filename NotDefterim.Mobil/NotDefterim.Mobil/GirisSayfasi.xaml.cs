using NotDefterim.Mobil.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefterim.Mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GirisSayfasi : ContentPage
    {
        public GirisSayfasi()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var pass = txtPass.Text;
            var logindata = new Dictionary<string, string>();
            logindata.Add("UserName", email);
            logindata.Add("password", pass);
            logindata.Add("grant_type", "password");
            var data = BenimServisim.Gonder<LoginData>("Token", logindata);
            if (data != null)
            {
                //Giriş Başarılı
                Application.Current.Properties["token"] = data.token_type + " " + data.access_token;
                Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Hata", "Kullanıcı Bulunamdı", "Tamam");
            }
        }
    }
}
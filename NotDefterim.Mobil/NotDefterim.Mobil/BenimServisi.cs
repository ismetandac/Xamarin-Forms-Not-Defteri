using Newtonsoft.Json;
using NotDefterim.Mobil.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace NotDefterim.Mobil
{
    public class BenimServisim
    {
        public static string ServisAdresi { get { return "http://api.m2m.gen.tr/"; } }
        public static T Getir<T>(string url, string token)
            where T : class
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Replace("bearer", "").Trim());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(new Uri(ServisAdresi + url)).Result;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(responseBody);

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static T Gonder<T>(string url, Dictionary<string, string> pairs)
         where T : class, new()
        {
            try
            {
                var client = new HttpClient();
                var gidecekicerik = new FormUrlEncodedContent(pairs);
                HttpResponseMessage r = client.PostAsync(ServisAdresi + url, gidecekicerik).Result;
                r.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                r.EnsureSuccessStatusCode();
                var icerik = r.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(icerik);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static T Gonder2<T>(string url, Dictionary<string, string> pairs, string token)
        where T : class, new()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Replace("bearer", "").Trim());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var gidecekicerik = new FormUrlEncodedContent(pairs);
                HttpResponseMessage r = client.PostAsync(ServisAdresi + url, gidecekicerik).Result;
                r.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                r.EnsureSuccessStatusCode();
                var icerik = r.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(icerik);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

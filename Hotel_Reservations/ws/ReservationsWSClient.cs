using Reservations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace Hotel_Reservations.ws
{
    public class ReservationsWSClient
    {
        private static string GET_ALL_URL = "http://localhost:8080/javarest/Reservations";
        private static string urlParameters = "";

        public IEnumerable<Reservation> GetAllReservations()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result; 
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Reservation> reservations = response.Content.ReadAsAsync<IEnumerable<Reservation>>().Result;
                var rl = reservations.ToList();
                return rl;              

            }
            else
            {
                return null;
            }
        }

        public Reservation GetReservation(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Reservations/" + id).Result;
            if (response.IsSuccessStatusCode)
            {                
                var r = response.Content.ReadAsAsync<Reservation>().Result;
                return r;
            }
            else
            {
                return null;
            }
        }


        public void DeleteReservation(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            client.DeleteAsync("/javarest/Reservations/" + id).Wait();
        }

        public void CreateReservation(Reservation r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var jrRaw = new JavaScriptSerializer().Serialize(r);
            string jr = Regex.Replace(jrRaw, @"""\\/Date\((\d+)\)\\/""", "$1");
            var content = new StringContent(jr.ToString(), Encoding.UTF8, "application/json");
            client.PostAsync(@"/javarest/Reservations/", content).Wait();
        }

        public void EditReservation(Reservation r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var jrRaw = new JavaScriptSerializer().Serialize(r);
            string jr = Regex.Replace(jrRaw, @"""\\/Date\((\d+)\)\\/""", "$1");
            var content = new StringContent(jr.ToString(), Encoding.UTF8, "application/json");
            client.PutAsync(@"/javarest/Reservations/", content).Wait();
        }
    }
}
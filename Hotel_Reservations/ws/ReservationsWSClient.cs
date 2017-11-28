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

        public IEnumerable<Reservation> getAllReservations()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result; 
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Reservation> reservations = response.Content.ReadAsAsync<IEnumerable<Reservation>>().Result;
                //TODO replace by WS calls
                ModelReservations db = new ModelReservations();
                var rl = reservations.ToList();
                rl.ForEach(r => r.RoomType1 = db.RoomTypes.Find(r.roomType));
                return rl;
                 

            }
            else
            {
                return null;
            }
        }

        public Reservation getReservation(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Reservations/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                
                var r = response.Content.ReadAsAsync<Reservation>().Result;
                //TODO replace by WS calls
                ModelReservations db = new ModelReservations();
                r.Country1 = db.Countries.Find(r.country);
                r.Region1 = db.Regions.Find(r.region);
                r.RoomType1 = db.RoomTypes.Find(r.roomType);
                r.CreditCardType1 = db.CreditCardTypes.Find(r.CreditCardType);
                return r;
            }
            else
            {
                return null;
            }
        }


        public void deleteReservation(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            client.DeleteAsync("/javarest/Reservations/" + id).Wait();
        }

        public void createReservation(Reservation r)
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
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
    public class ReservedRoomsWSClient
    {
        private static string GET_ALL_URL = "http://localhost:8080/javarest/ReservedRooms";
        private static string urlParameters = "";

        public IEnumerable<ReservedRoom> GetAllReservedRooms()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result; 
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<ReservedRoom> rr = response.Content.ReadAsAsync<IEnumerable<ReservedRoom>>().Result;
                var rl = rr.ToList();
                return rl;              

            }
            else
            {
                return null;
            }
        }

        public ReservedRoom GetReservedRoom(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/ReservedRooms/" + id).Result;
            if (response.IsSuccessStatusCode)
            {                
                var r = response.Content.ReadAsAsync<ReservedRoom>().Result;
                return r;
            }
            else
            {
                return null;
            }
        }


        public void DeleteReservedRooms(int reservationId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            client.DeleteAsync("/javarest/ReservedRooms/" + reservationId).Wait();
        }

        public void CreateReservedRoom(ReservedRoom r)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var jrRaw = new JavaScriptSerializer().Serialize(r);
            var content = new StringContent(jrRaw.ToString(), Encoding.UTF8, "application/json");
            client.PostAsync(@"/javarest/ReservedRooms/", content).Wait();
        }

    }
}
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
    public class RoomWSClient
    {
 
        private static string GET_ALL_URL = "http://localhost:8080/javarest/Rooms";
        private static string urlParameters = "";

        public IEnumerable<Room> GetAllRooms()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Room> room = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                var rl = room.ToList();
                return rl;

            }
            else
            {
                return null;
            }
        }

        public Room GetRoom(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Rooms/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<Room>().Result;
                return r;
            }
            else
            {
                return null;
            }
        }


        public void DeleteRoom(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            client.DeleteAsync("/javarest/Rooms/" + id).Wait();
        }

       
    }
}
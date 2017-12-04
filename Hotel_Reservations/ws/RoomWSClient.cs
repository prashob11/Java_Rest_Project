using Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Hotel_Reservations.ws
{
    public class RoomWSClient
    {
 
        private static string GET_ALL_URL = WSConfig.Host + "/javarest/Rooms";

        public IEnumerable<Room> GetAllRooms()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
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
      
    }
}
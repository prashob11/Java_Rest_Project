using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Reservations;

namespace Hotel_Reservations.ws
{
    public class RoomTypesWSClient
    {
        private static string GET_ALL_URL = "http://localhost:8080/javarest/RoomType";
        private static string urlParameters = "";

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<RoomType> roomTypes = response.Content.ReadAsAsync<IEnumerable<RoomType>>().Result;
                var rt = roomTypes.ToList();
                return rt;

            }
            else
            {
                return null;
            }
        }

        public RoomType GetRoomType(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/RoomType/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var rt = response.Content.ReadAsAsync<RoomType>().Result;
                return rt;
            }
            else
            {
                return null;
            }
        }
    }
}
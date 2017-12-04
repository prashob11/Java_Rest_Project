using Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Hotel_Reservations.ws
{
    public class CityWSClient
    {
        private static string GET_ALL_URL = WSConfig.Host +"/javarest/Cities";

        public IEnumerable<City> GetAllCities()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<City> Cities = response.Content.ReadAsAsync<IEnumerable<City>>().Result;
                var rl = Cities.ToList();
                return rl;

            }
            else
            {
                return null;
            }
        }

        public IEnumerable<City> GetCitiesByRegionId(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Cities/byRegion" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<City> Cities = response.Content.ReadAsAsync<IEnumerable<City>>().Result;
                var rl = Cities.ToList();
                return rl;
            }
            else
            {
                return null;
            }
        }


        public City GetCity(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Cities/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<City>().Result;
                return r;
            }
            else
            {
                return null;
            }
        }

    }
}
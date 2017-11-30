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
    public class CityWSClient
    {
        private static string GET_ALL_URL = "http://localhost:8080/javarest/Cities";
        private static string urlParameters = "";

        public IEnumerable<City> GetAllCities()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
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
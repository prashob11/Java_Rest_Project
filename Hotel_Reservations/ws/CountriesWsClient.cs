using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Reservations;

namespace Hotel_Reservations.ws
{
    public class CountriesWsClient
    {
        private static string GET_ALL_URL = WSConfig.Host + "/javarest/Countries";

        public IEnumerable<Country> GetAllCountries()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Country> countries = response.Content.ReadAsAsync<IEnumerable<Country>>().Result;
                var ct = countries.ToList();
                return ct;

            }
            else
            {
                return null;
            }
        }

        public Country GetCountry(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/Countries/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var ct = response.Content.ReadAsAsync<Country>().Result;
                return ct;
            }
            else
            {
                return null;
            }
        }
    }
}
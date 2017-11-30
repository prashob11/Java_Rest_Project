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
    public class CreditCardTypeWSClient
    {
        private static string GET_ALL_URL = "http://localhost:8080/javarest/CreditCardType";
        private static string urlParameters = "";

        public IEnumerable<CreditCardType> GetAllCreditCardTypes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<CreditCardType> CCTypes = response.Content.ReadAsAsync<IEnumerable<CreditCardType>>().Result;
                var rl = CCTypes.ToList();
                return rl;

            }
            else
            {
                return null;
            }
        }

        public CreditCardType GetCreditCardType(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GET_ALL_URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/javarest/CreditCardType/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var r = response.Content.ReadAsAsync<CreditCardType>().Result;
                return r;
            }
            else
            {
                return null;
            }
        }



    }
}
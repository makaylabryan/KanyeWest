using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonSwansonAndKanye
{
    public class QuoteGenerator
    {
        private HttpClient _httpClient;

        public QuoteGenerator (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string RonSwanson()
        {
            string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = _httpClient.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse);
            
            return ronQuote[0].ToString();
        }

        public string Kanye()
        {
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = _httpClient.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            
            return kanyeQuote;
        }
    }
}

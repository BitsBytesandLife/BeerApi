using Newtonsoft.Json;
using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace BeerApi
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var client = new HttpClient();

            //Beer List
            var beerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beers/?key=161c720690eee671fedfa68d633f403f").Result;

            //Random Beer
            var randomBeerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beer/random?key=161c720690eee671fedfa68d633f403f").Result;


            JToken rBeer = JToken.Parse(randomBeerResponse);
            var rBeerName = rBeer.SelectToken("data.name").ToString();
            Console.WriteLine(rBeerName);
            
            var beers = JsonConvert.DeserializeObject<BeerList>(beerResponse);

            foreach (var item in beers.data)
            {
                Console.WriteLine($"{item.name} {item.id}");
            }

        }
    }
}

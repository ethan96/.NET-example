using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54532/api/Players/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/XML")); 如果要用XML來交換資料就需改成這行，但是ReadAsAsync這個不支援XML轉換!

            Console.WriteLine("Try to get Player 2 data...");
            HttpResponseMessage resp = await client.GetAsync("2");
            if (resp.IsSuccessStatusCode)
            {
                Player player = await resp.Content.ReadAsAsync<Player>();
                string playerString = await resp.Content.ReadAsStringAsync();
                Console.WriteLine("ID: {0}, Name: {1}", player.ID, player.Name);
                Console.WriteLine("Original string is: {0}", playerString);
            }

            Console.WriteLine("");
            Console.WriteLine("Try to get all Players data");
            HttpResponseMessage resps = await client.GetAsync("");
            if (resps.IsSuccessStatusCode)
            {
                List<Player> players = await resps.Content.ReadAsAsync<List<Player>>();
                string playersString = await resps.Content.ReadAsStringAsync();
                foreach (var p in players)
                {
                    Console.WriteLine("ID: {0}, Name: {1}", p.ID, p.Name);
                }
                List<Player> jsPlayers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(playersString);
                foreach (var p in jsPlayers)
                {
                    Console.WriteLine("ID: {0}, Name: {1}", p.ID, p.Name);
                }
                //Console.WriteLine("Original string is: {0}", playersString);
            }
            Console.ReadKey();
        }
    }

    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

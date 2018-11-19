using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetData();
            //GetPlayer();
            GetPlayers();
        }

        private static void GetData()
        {
            string serviceUri = "http://localhost:10999/Service1.svc/";

            var request = WebRequest.Create(serviceUri + "GetData?value=10") as HttpWebRequest;
            var response = request.GetResponse();

            var resultStream = response.GetResponseStream();
            //var resultBuffer = new byte[1024];
            //var length = 1024;
            //var result = new StringBuilder();
            //while (length == 1024)
            //{
            //    length = resultStream.Read(resultBuffer, 0, 1024);
            //    string resultString = System.Text.Encoding.UTF8.GetString(resultBuffer, 0, length);
            //    result.Append(resultString);
            //}

            //Console.WriteLine(result.ToString());

            StreamReader sr = new StreamReader(resultStream);
            string myresult = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(myresult);
        }

        private static void GetPlayer()
        {
            string serviceUri = "http://localhost:10999/Service1.svc/";

            var request = WebRequest.Create(serviceUri + "Player?id=1") as HttpWebRequest;
            var response = request.GetResponse();
            var resultStream = response.GetResponseStream();

            //DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
            //var player = json.ReadObject(resultStream) as Player;
            //if (player != null)
            //{
            //    Console.WriteLine("Player's ID = " + player.ID + ", Player's name = " + player.Name);
            //}
            //Console.ReadKey();
        }

        private static void GetPlayers()
        {
            string serviceUri = "http://localhost:10999/Service1.svc/";

            var request = WebRequest.Create(serviceUri + "Players?id=1") as HttpWebRequest;
            var response = request.GetResponse();
            var resultStream = response.GetResponseStream();

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Player>));
            var players = json.ReadObject(resultStream) as List<Player>;
            if (players != null)
            {
                foreach (var player in players)
                {
                    Console.WriteLine("ID: " + player.ID + " Name: " + player.Name);
                }
            }
            Console.ReadKey();
        }
    }
}

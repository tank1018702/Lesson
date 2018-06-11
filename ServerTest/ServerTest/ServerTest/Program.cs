using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ServerTest
{
    class Program
    {
        private const string url = "https://www.baidu.com/";
        
        static void Main(string[] args)
        {

            GetDataSimpleAsync().Wait();
            Console.ReadKey();


        }
        private static async Task GetDataSimpleAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("StatusCode:{0}", (int)response.StatusCode);

                    string responseText = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("TextLength:{0}", responseText.Length);
                }
            }
        }
       
    }
}

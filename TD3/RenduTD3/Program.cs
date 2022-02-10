using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RenduTD3
{
    class Program
    {
        static Contact[] contacts;
        static Station[] stations;
        private static async Task Question1(string uri)
        {

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                

                contacts = JsonSerializer.Deserialize<Contact[]>(responseBody);
                
                /*Console.WriteLine("deserialized object : \n");
                Console.Write("[");
                for(int i = 0; i < contacts.Length; i++)
                {
                    if(i< contacts.Length - 1) Console.Write(contacts[i].ToString()+",");
                    else Console.Write(contacts[i].ToString());
                }
                Console.Write("]");
                Console.ReadLine();*/
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        static async Task question2(String uri)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.ReadLine();
                stations =JsonSerializer.Deserialize<Station[]>(responseBody);
                Console.WriteLine(stations[0].ToString());
                Console.ReadLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await Question1(args[0]);
            Console.WriteLine("Hello world!");
            Console.ReadLine();
            Console.WriteLine(args[1]);
            await question2(args[1]);
        }

      
    }
}

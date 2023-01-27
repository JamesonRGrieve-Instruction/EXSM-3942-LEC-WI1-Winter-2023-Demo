using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncExample();

            Console.ReadLine();
        }
        static async void AsyncExample()
        {
            {
                // ----
                // All Info
                // ----
                // Generate a client to handle our HTTP request.
                HttpClient client = new HttpClient();
                // Houses the response object for the request.
                HttpResponseMessage response;
                // URL for our request.
                string destination = "http://numbersapi.com/random/math";
                // Send the request and wait for a response.
                response = await client.GetAsync(destination);
                // Process the response into a byte array.
                byte[] responseContent = await response.Content.ReadAsByteArrayAsync();
                // Encode the byte array into a string using the default encoding system.
                string responseString = Encoding.Default.GetString(responseContent);
                // Display the response string.
                Console.WriteLine(responseString);
            }
            {
                // ----
                // String Result
                // ----
                // Generate a client to handle our HTTP request.
                HttpClient client = new HttpClient();
                // URL for our request.
                string destination = "http://numbersapi.com/random/math";
                // Send the request and wait for a response.
                string responseString = await client.GetStringAsync(destination);
                // Display the response string.
                Console.WriteLine(responseString);
            }
            {
                // ----
                // JSON Result
                // ----
                // Generate a client to handle our HTTP request.
                HttpClient client = new HttpClient();
                // URL for our request.
                string destination = "https://pokeapi.co/api/v2/pokemon/pikachu";
                // Send the request and wait for a response.
                string responseString = await client.GetStringAsync(destination);
                // Process the response into JSON.
                Pokemon myDeserializedClass = JsonConvert.DeserializeObject<Pokemon>(responseString);
                Console.WriteLine(myDeserializedClass.Types[0].Type.Name);
            }

        }
    }
}
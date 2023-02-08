using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the endpoint number to call:");
            Console.WriteLine("1. Get all users");
            Console.WriteLine("2. Get user by id");
            Console.WriteLine("3. Add user");
            Console.WriteLine("4. Update user");
            Console.WriteLine("5. Delete user");

            int endpointNumber = Convert.ToInt32(Console.ReadLine());

            while (endpointNumber < 1 || endpointNumber > 5)
            {
                Console.WriteLine("Invalid endpoint number. Enter a number between 1 and 5.");
                endpointNumber = Convert.ToInt32(Console.ReadLine());
            }

            string apiBaseUri = "https://localhost:7118/api/";


            switch (endpointNumber)
            {
                case 1:
                    Console.WriteLine("Getting all users...");
                    CallEndpoint1(apiBaseUri);
                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Getting user by id...");
                    throw new NotImplementedException();

                case 3:
                    Console.WriteLine("Adding user...");
                    throw new NotImplementedException();

                case 4:
                    Console.WriteLine("Updating user...");
                    throw new NotImplementedException();

                case 5:
                    Console.WriteLine("Deleting user...");
                    throw new NotImplementedException();
            }
        }

        static void CallEndpoint1(string apiBaseUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("User").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Success: " + data);
            }
            else
            {
                Console.WriteLine("Error Code: " + response.StatusCode + " : Message: " + response.ReasonPhrase);
            }
        }
    }
}

namespace Distance_Calculator_REST_Client
{
    using System;
    using RestSharp;


    class RestClient
    {

        static void Main()
        {
            var client = new RestSharp.RestClient("http://localhost:52720");
            var request = new RestRequest("api/points/distance", Method.GET);

            request.AddParameter("startX", 10);
            request.AddParameter("startY", 10);
            request.AddParameter("endX", 15);
            request.AddParameter("endY", 15);

            var response = client.Execute(request);
            var statusCode = response.StatusCode;

            if (statusCode == 0)
            {
                Console.WriteLine("Server is not started.");
                Console.WriteLine("Your port can be different.");
                Console.WriteLine("Please run project \"_03_Distance-Calculator-REST-service\".");
                return;
            }

            var result = response.Content;

            Console.WriteLine("The distance between two points is: {0}", result);
        }
    }
}

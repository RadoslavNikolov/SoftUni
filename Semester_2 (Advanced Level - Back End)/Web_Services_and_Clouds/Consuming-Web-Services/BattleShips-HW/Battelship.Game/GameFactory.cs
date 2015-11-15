namespace Battelship.Game
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Battleships.WebServices.Models;
    using Battleships.WebServices.Models.DTO;
    using FileHelpers;
    using ErrorInfo = Battleships.WebServices.Models.ErrorInfo;


    public static class GameFactory
    {
        internal static string LoginToken = String.Empty;
        private const string LoginEndpoint = "http://localhost:62858/Token";
        private const string RegisterEndpoint = "http://localhost:62858/api/account/register";
        private const string GameCreateEndpoint = "http://localhost:62858/api/games/create";
        private const string JoinGameEndpoint = "http://localhost:62858/api/games/join";
        private const string PlayGameEndpoint = "http://localhost:62858/api/games/play";



        public static async void Login(params string[] input)
        {
            if (LoginToken != string.Empty)
            {
                Console.WriteLine("Already logged!");
                return;
            }

            var email = input[2];
            var password = input[3];
            var httpClient = new HttpClient();
            using (httpClient)
            {               
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")   
                });

                var request = await httpClient.PostAsync(LoginEndpoint, content);

                if (!request.IsSuccessStatusCode)
                {
                    // Nothing to return, throw a proper exception + message
                    throw new HttpRequestException(
                        request.Content.ReadAsStringAsync().Result);
                }

                var response =  request.Content.ReadAsAsync<LoginBindingModel>().Result;

                LoginToken = response.Access_Token;
                Console.WriteLine("Logic successful!");
            }
        }


        internal static async void Register(params string[] input)
        {
            var email = input[2];
            var password = input[3];
            var confirmPassword = input[4];
            var httpClient = new HttpClient();

            using (httpClient)
            {               
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPassword),
                });



                var request = await httpClient.PostAsync(RegisterEndpoint, bodyData);
                if (!request.IsSuccessStatusCode)
                {                
                    var response = request.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(response);
                    return;                 
                }

                Console.WriteLine("Register user: {0}", email);

            }
        }

        internal static async void PlayGame(params string[] input)
        {
            var gameId = input[2];
            var positionX = input[3];
            var positionY = input[4];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + LoginToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId),
                    new KeyValuePair<string, string>("PositionX", positionX),
                    new KeyValuePair<string, string>("PostionY", positionY)
                });

                var request = await httpClient.PostAsync(JoinGameEndpoint, bodyData);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                    return;
                }

                var userId = request.Content.ReadAsStringAsync();
                Console.WriteLine("User {0} made a tyrn", userId);
            }
        }

        internal static async void JoinGame(params string[] input)
        {
            var gameId = input[2];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + LoginToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId)
                });

                var request = await httpClient.PostAsync(JoinGameEndpoint, bodyData);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                    return;
                }
              
                Console.WriteLine("Joined game with id: {0}", gameId);
            }
        }
        
        internal static async void CreateGame()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + LoginToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("", "")
                });

                var request = await httpClient.PostAsync(GameCreateEndpoint, bodyData);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                    return;
                }

                var gameId = request.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Game with id: {0} was created.", gameId);
            }
        }
    }
}
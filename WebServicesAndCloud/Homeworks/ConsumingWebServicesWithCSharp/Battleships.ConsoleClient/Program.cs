namespace Battleships.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;

    class Program
    {
        private const string RegisterEndpoint = "http://localhost:62858/api/account/register";
        private const string LoginEndpoint = "http://localhost:62858/Token";
        private const string CreateGameEndpoint = "http://localhost:62858/api/games/create";
        private const string JoinGameEndpoint = "http://localhost:62858/api/games/join";
        private const string PlayEndpoint = "http://localhost:62858/api/games/play";

        private static string token = "";

        static void Main(string[] args)
        {
            while (true)
            {
                string[] inputParameters = Console.ReadLine().Split(' ');
                string command = inputParameters[0];
                if (command == "end")
                {
                    break;
                }
                switch (command)
                {
                    case "register":
                        Register(inputParameters[1], inputParameters[2], inputParameters[3]);
                        break;
                    case "login":
                        Login(inputParameters[1], inputParameters[2]);
                        break;
                    case "create-game":
                        CreateGame();
                        break;
                    case "join-game":
                        JoinGame(inputParameters[1]);
                        break;
                    case "play":
                        Play(inputParameters[1], inputParameters[2], inputParameters[3]);
                        break;
                    default:
                        Console.WriteLine("No such command: {0}", command);
                        break;
                }
            }
        }

        private static async void Register(string email, string password, string confirmPassword)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPassword)
                });
                var response = await httpClient.PostAsync(RegisterEndpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync());
                }

                Console.WriteLine("User {0} registered successfully", email);
            }
        }

        private static async void Login(string email, string password)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("username", email),
                    new KeyValuePair<string,string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });
                var response = await httpClient.PostAsync(LoginEndpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync());
                }
                var user = await response.Content.ReadAsAsync<LoginData>();

                token = user.Access_Token;

                Console.WriteLine("Username: {0}, Token: {1}", user.Username, user.Access_Token);
            }
        }

        private static async void CreateGame()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
                
                var response = await httpClient.PostAsync(CreateGameEndpoint, null);

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private static async void JoinGame(string gameId)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));

                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("gameId", gameId)
                });
                var response = await httpClient.PostAsync(JoinGameEndpoint, content);

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private static async void Play(string gameId, string positionX, string positionY)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("gameId", gameId),
                    new KeyValuePair<string, string>("positionX", positionX),
                    new KeyValuePair<string, string>("positionY", positionY)
                });
                var response = await httpClient.PostAsync(PlayEndpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync());
                }

                Console.WriteLine("You attacked position {0} {1}", positionX, positionY);
            }
        }
    }
}

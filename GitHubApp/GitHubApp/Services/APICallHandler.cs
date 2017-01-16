using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitHubApp.Models;

namespace GitHubApp.Services

{
    public class APICallHandler
    {

        //TODO: add error handling here
        public static async Task<List<Repository>> GetUserRepositories(string userName)
        {
            const string BaseUrl = "https://api.github.com/users/";
            List<Repository> userRepositories = new List<Repository>();

            var client = new HttpClient() { BaseAddress = new Uri(BaseUrl + userName + "/repos") };

            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.13) Gecko/20080311 Firefox/2.0.0.13");

            var jsonResponse = string.Empty;

            using (client)
            {
                var getDataResponse = await client.GetAsync("", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);

                //If we do not get a successful status code, then return an empty set
                if (!getDataResponse.IsSuccessStatusCode)
                    jsonResponse = null;
                else
                    //Retrieve the JSON response
                    jsonResponse = await getDataResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (jsonResponse != null)
                {
                    userRepositories = JsonConvert.DeserializeObject<List<Repository>>(jsonResponse);
                }

            }

            return userRepositories;

        }
    }
}

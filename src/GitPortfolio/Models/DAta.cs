using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GitPortfolio.Models
{
    public class Data
    {
        public int stargazers_count { get; set; }
        public string Name { get; set; }
        public string html_url { get; set; }

        public static List<Data> GetRepos()
        {
            var client = new RestClient("https://api.github.com/users");
            var request = new RestRequest("Fealios/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "Fealios");
            //request.AddHeader("Authorization", "token 6b275ac48cd73c16813d51e41b80f87e1662fc78");

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Data>>(jsonResponse.ToString());

            return Filter(repoList);
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static List<Data> Filter(List<Data> unfiltered)
        {
            Data temp;
            for(int write = 0; write < unfiltered.Count; write++)
            {
                for(int sort = 0; sort < unfiltered.Count - 1; sort++)
                {
                    if (unfiltered[sort].stargazers_count < unfiltered[sort + 1].stargazers_count)
                    {
                        temp = unfiltered[sort + 1];
                        unfiltered[sort + 1] = unfiltered[sort];
                        unfiltered[sort] = temp;
                    }
                }
            }

            List<Data> sorted = new List<Data> { unfiltered[0], unfiltered[1], unfiltered[2] };
            return sorted;
        }
    }
}

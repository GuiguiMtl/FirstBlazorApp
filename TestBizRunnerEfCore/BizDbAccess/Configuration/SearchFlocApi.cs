using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Dtos;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace BizDbAccess.Configuration
{
    public class SearchFlocApi : ISearchFlocApi
    {
        private RestClient _client;

        public SearchFlocApi(IConfiguration config)
        {
            var rootUrl = config["ConfigurationApiUrl"];
            _client = new RestClient(rootUrl);
        }

        public ActualNodeDetailsDto SearchFlocByName(string flocName)
        {
            var request = new RestRequest("/ActualNode");
            request.AddQueryParameter("name", flocName);

            var response = _client.Execute<ActualNodeDetailsDto>(request);
            return response.Data;
        }
    }
}

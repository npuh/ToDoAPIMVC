using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TodoMVC
{
    public static class ClientVariables
    {
        public static HttpClient apiClient = new HttpClient();

        static ClientVariables()
        {
            apiClient.BaseAddress = new Uri("http://localhost:19101/Api/");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
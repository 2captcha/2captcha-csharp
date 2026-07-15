using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TwoCaptcha.Exceptions;

namespace TwoCaptcha
{
    public class GenericApiClient
    {
        private int softId = 4582;
        string apiKey;
        private long id;
        int timeout = 160;
        int pollingInterval = 10;
        HttpClient httpClient = new HttpClient();        
        string createTaskUri = "https://api.2captcha.com/createTask";
        string getTaskResultUri = "https://api.2captcha.com/getTaskResult";

        public GenericApiClient(string apiKey)
        {
            this.apiKey = apiKey;
        }
        /*
         var jsonObject = new System.Text.Json.Nodes.JsonObject()
  {

   ["firstName"] = JsonValue.Create("Doofus"),
   ["lastName "] = JsonValue.Create("Flintstones"),
   ["address"] = new System.Text.Json.Nodes.JsonObject
   {
    ["line1"]= "Stockholm",
    ["line2"]= "Sweden"
   },
   ["knowsCSharp"] = JsonValue.Create(true),
   ["yearsAtDev "] = JsonValue.Create<int>(5),
   ["hobbies"] = new JsonArray() { "music", "dance"}

  };
         */
        public JObject solve(JObject jsonObject)/* throws Exception*/
        {
            jsonObject.Add("softId", softId);
            JObject responseJsonObject = createTask(jsonObject);

            Console.WriteLine("resp");
            return null;
            /*
        this.id = responseJsonObject.getLong("taskId");

        if (jsonObject.getJSONObject("task").has("callbackUrl")
                && !jsonObject.getJSONObject("task").getString("callbackUrl").isEmpty())
            return responseJsonObject;
        return getTaskResult(this.id);
            */
        }


        private JObject createTask(JObject jsonObject)/* throws IOException, InterruptedException*/ {

            JsonContent content = JsonContent.Create(jsonObject);
            using var response = httpClient.PostAsync(createTaskUri, content);

            Console.WriteLine("CreateTask Request");
            Console.WriteLine("Status: " + response);
            Console.WriteLine("Status: " + response);

            return null;
            //System.out.println("Body: " + response.body());
            /*
        JSONObject responseJsonObject = new JSONObject(response.body());
        return responseJsonObject;
            */
    }




        /**
         * API server
         */
        private string baseUrl = "https://2captcha.com/";

        /**
         * Network client
         */
        private readonly HttpClient client = new HttpClient();

        /*
        public ApiClient()
        {
            client.BaseAddress = new Uri(baseUrl);
        }
        */

        public virtual async Task<string> In(Dictionary<string, string> parameters, Dictionary<string, FileInfo> files)
        {
            var content =
                new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));

            foreach (KeyValuePair<string, string> p in parameters)
            {
                content.Add(new StringContent(p.Value), p.Key);
            }

            foreach (KeyValuePair<string, FileInfo> f in files)
            {
                var fileStream = new StreamContent(new MemoryStream(File.ReadAllBytes(f.Value.FullName)));
                content.Add(fileStream, f.Key, f.Value.Name);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "in.php")
            {
                Content = content
            };

            return await Execute(request);
        }

        public virtual async Task<string> Res(Dictionary<string, string> parameters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "res.php?" + BuildQuery(parameters));

            return await Execute(request);
        }

        private string BuildQuery(Dictionary<string, string> parameters)
        {
            string query = "";

            foreach (KeyValuePair<string, string> p in parameters)
            {
                if (query.Length > 0)
                {
                    query += "&";
                }

                query += p.Key + "=" + Uri.EscapeDataString(p.Value);
            }

            return query;
        }

        private async Task<string> Execute(HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);

            string body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new NetworkException("Unexpected response: " + body);
            }

            if (body.StartsWith("ERROR_"))
            {
                throw new ApiException(body);
            }

            return body;
        }
    }
}
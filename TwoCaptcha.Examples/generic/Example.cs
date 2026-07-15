using System;
using System.Linq;

using TwoCaptcha;

namespace TwoCaptcha.Examples
{
    public class Example
    {
        private String apiKey;
        public Example(string apiKey)
        {
            this.apiKey = apiKey;


            /*
            GenericApiClient solver = new TwoCaptcha.GenericApiClient(apiKey);

            Text captcha = new Text("If tomorrow is Saturday, what day is today?");

            try
            {
                solver.Solve(captcha).Wait();
                Console.WriteLine("Captcha solved: " + captcha.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }*/
        }
        /*
        private void resolve()
        {
            ApiClient apiClient = new ApiClient(this.key);
            JSONObject innerJsonObject = new JSONObject()
                    .put("type", "TextCaptchaTask")
                    .put("comment", "If tomorrow is Saturday, what day is today?");

            JSONObject jsonObject = new JSONObject();
            jsonObject.put("clientKey", this.key);
            jsonObject.put("languagePool", "en");
            jsonObject.put("task", innerJsonObject);

            try
            {
                JSONObject resultJsonObject = apiClient.solve(jsonObject);
                System.out.println("Result: " + resultJsonObject.toString());
            }
            catch (Exception e)
            {
                System.out.println("Error occurred: " + e.getMessage());
            }

        }*/
    }
}
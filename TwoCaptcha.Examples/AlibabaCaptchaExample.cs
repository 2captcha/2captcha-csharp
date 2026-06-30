using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class AlibabaCaptchaExample
    {
        public AlibabaCaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            AlibabaCaptcha captcha = new AlibabaCaptcha();
            captcha.SetSceneId("login");
            captcha.SetPrefix("https://img.alicdn.com/tfs/...");
            captcha.SetPageUrl("https://example.com/page-with-alibaba");

            try
            {
                solver.Solve(captcha).Wait();
                Console.WriteLine("Captcha solved: " + captcha.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }
    }
}

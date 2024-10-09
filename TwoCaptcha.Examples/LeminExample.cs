using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class LeminExample
    {
        public LeminExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Lemin captcha = new Lemin();
            captcha.SetCaptchaId("CROPPED_3dfdd5c_d1872b526b794d83ba3b365eb15a200b");
            captcha.SetApiServer("api.leminnow.com");
            captcha.SetUrl("https://2captcha.com/demo/lemin");

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
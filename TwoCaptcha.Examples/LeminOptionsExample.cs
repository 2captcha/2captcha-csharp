using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class LeminOptionsExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            Lemin captcha = new Lemin();
            captcha.SetCaptchaId("CROPPED_d3d4d56_73ca4008925b4f83a8bed59c2dd0df6d");
            captcha.SetApiServer("api.leminnow.com");
            captcha.SetUrl("http://sat2.aksigorta.com.tr");
            captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");

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
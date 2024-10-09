using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class FriendlyCaptchaExample
    {
        public FriendlyCaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            FriendlyCaptcha captcha = new FriendlyCaptcha();
            captcha.SetSiteKey("2FZFEVS1FZCGQ9");
            captcha.SetUrl("https://example.com");

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
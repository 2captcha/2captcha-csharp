using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class FriendlyCaptchaExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

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
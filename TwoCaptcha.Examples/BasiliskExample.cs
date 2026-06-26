using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class BasiliskExample
    {
        public BasiliskExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Basilisk captcha = new Basilisk();
            captcha.SetSiteKey("b7890h...19fb2600897");
            captcha.SetPageUrl("https://example.com/login");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36");
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

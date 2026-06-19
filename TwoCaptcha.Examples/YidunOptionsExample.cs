using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class YidunOptionsExample
    {
        public YidunOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Yidun captcha = new Yidun();
            captcha.SetSiteKey("0f743r3g1...8rz3grz0ym5");
            captcha.SetPageUrl("https://example.com/page-with-yidun");
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
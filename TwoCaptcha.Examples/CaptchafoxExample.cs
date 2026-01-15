using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CaptchafoxExample
    {
        public CaptchafoxExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Captchafox captcha = new Captchafox();
            captcha.SetSiteKey("sk_ILKWNruBBVKDOM7dZs59KHnDLEWiH");
            captcha.SetUrl("https://mysite.com/page/with/captchafox");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
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
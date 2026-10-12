using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class ImpervaExample
    {
        public ImpervaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Imperva captcha = new Imperva();
            captcha.SetPageUrl("https://example.com/login");
            captcha.SetIncapsulaScriptUrl("/_Incapsula_Resource?SWUDNSAI=31&xinfo=1");
            captcha.SetIncapsulaCookies("visid_incap_123456=sample; incap_ses_123_123456=sample");
            captcha.SetReese84UrlEndpoint("https://example.com/_Incapsula_Resource?reese84=1");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36");
            captcha.SetProxy("HTTP", "login:password@1.2.3.4:8080");

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

using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class TspdExample
    {
        public TspdExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Tspd captcha = new Tspd();
            captcha.SetPageUrl("https://example.com/login");
            captcha.SetTspdCookie("TS386a400d029=082670...010245; TS386a400d078=082670...dbb3b0c");
            captcha.SetHtmlPageBase64("PCFET0NUWVBFIGh0bWw+...");
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
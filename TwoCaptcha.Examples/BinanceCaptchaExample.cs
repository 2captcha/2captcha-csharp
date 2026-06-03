using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class BinanceCaptchaExample
    {
        public BinanceCaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            BinanceCaptcha captcha = new BinanceCaptcha();
            captcha.SetSiteKey("login");
            captcha.SetPageUrl("https://example.com/page-with-binance");
            captcha.SetValidateId("cb0bfef...e54ecd57b");

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
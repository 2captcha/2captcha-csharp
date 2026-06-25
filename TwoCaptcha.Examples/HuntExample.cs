using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class HuntExample
    {
        public HuntExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Hunt captcha = new Hunt();
            captcha.SetUrl("https://example.com/page-with-hunt");
            captcha.SetApiGetLib("https://example.com/hd-api/external/apps/app-id/api.js");
            captcha.SetData("meta.token.value");
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

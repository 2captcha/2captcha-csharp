using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class TencentExample
    {
        public TencentExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Tencent tencent = new Tencent();
            tencent.SetAppId("190014885");
            tencent.SetPageUrl("https://www.example.com/");

            try
            {
                solver.Solve(tencent).Wait();
                Console.WriteLine("Captcha solved: " + tencent.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }
    }
}
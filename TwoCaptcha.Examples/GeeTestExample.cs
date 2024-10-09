using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GeeTestExample
    {
        public GeeTestExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            GeeTest captcha = new GeeTest();
            captcha.SetGt("f2ae6cadcf7886856696502e1d55e00c");
            captcha.SetApiServer("api.geetest.com");
            captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
            captcha.SetUrl("https://2captcha.com/demo/geetest");

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
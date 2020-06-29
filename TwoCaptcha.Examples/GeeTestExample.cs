using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GeeTestExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            GeeTest captcha = new GeeTest();
            captcha.SetGt("f2ae6cadcf7886856696502e1d55e00c");
            captcha.SetApiServer("api-na.geetest.com");
            captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
            captcha.SetUrl("https://mysite.com/captcha.html");

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
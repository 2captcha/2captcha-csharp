using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GeeTestV4OptionsExample
    {
        public GeeTestV4OptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            GeeTestV4 captcha = new GeeTestV4();
            captcha.SetCaptchaId("72bf15796d0b69c43867452fea615052");
            captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
            captcha.SetUrl("https://2captcha.com/demo/geetest-v4");
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
using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class ReCaptchaV3OptionsExample
    {
        public ReCaptchaV3OptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            ReCaptcha captcha = new ReCaptcha();
            captcha.SetSiteKey("6LfB5_IbAAAAAMCtsjEHEHKqcB9iQocwwxTiihJu");
            captcha.SetUrl("https://2captcha.com/demo/recaptcha-v3");
            captcha.SetVersion("v3");
            captcha.SetDomain("google.com");
            captcha.SetAction("demo_action");
            captcha.SetScore(0.3);
            captcha.SetEnterprise(false);
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
using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class AltchacaptchaExample
    {
        public AltchacaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Altchacaptcha captcha = new Altchacaptcha();
            captcha.SetChallengeUrl("https://.../captcha/api/altcha/challenge");
            captcha.SetPageUrl("https://site.com/");

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
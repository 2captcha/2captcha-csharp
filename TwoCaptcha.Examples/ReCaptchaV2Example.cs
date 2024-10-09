using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class ReCaptchaV2Example
    {
        public ReCaptchaV2Example(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            ReCaptcha captcha = new ReCaptcha();
            captcha.SetSiteKey("6LfD3PIbAAAAAJs_eEHvoOl75_83eXSqpPSRFJ_u");
            captcha.SetUrl("https://2captcha.com/demo/recaptcha-v2");

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
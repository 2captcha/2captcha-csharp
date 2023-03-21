using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class TurnstileExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            Turnstile captcha = new Turnstile();
            captcha.SetSiteKey("0x4AAAAAAAChNiVJM_WtShFf");
            captcha.SetUrl("https://ace.fusionist.io");

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
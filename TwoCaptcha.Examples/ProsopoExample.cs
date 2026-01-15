using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class ProsopoExample
    {
        public ProsopoExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Prosopo captcha = new Prosopo();
            captcha.SetSiteKey("5EZVvsHMrKCFKp5NYNoTyDjTjetoVo1Z4UNNbTwJf1GfN6Xm");
            captcha.SetUrl("https://www.twickets.live/");

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
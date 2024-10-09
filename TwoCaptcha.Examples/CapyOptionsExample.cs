using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CapyOptionsExample
    {
        public CapyOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Capy captcha = new Capy();
            captcha.SetSiteKey("PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v");
            captcha.SetUrl("https://www.mysite.com/captcha/");
            captcha.SetApiServer("https://jp.api.capy.me/");
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
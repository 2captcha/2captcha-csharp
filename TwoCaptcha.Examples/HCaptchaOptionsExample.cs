using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class HCaptchaOptionsExample
    {
        public HCaptchaOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            HCaptcha captcha = new HCaptcha();
            captcha.SetSiteKey("c0421d06-b92e-47fc-ab9a-5caa43c04538");
            captcha.SetUrl("https://2captcha.com/demo/hcaptcha");
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
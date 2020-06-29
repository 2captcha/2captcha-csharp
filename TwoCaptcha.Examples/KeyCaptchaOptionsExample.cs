using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class KeyCaptchaOptionsExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            KeyCaptcha captcha = new KeyCaptcha();
            captcha.SetUserId(10);
            captcha.SetSessionId("493e52c37c10c2bcdf4a00cbc9ccd1e8");
            captcha.SetWebServerSign("9006dc725760858e4c0715b835472f22");
            captcha.SetWebServerSign2("2ca3abe86d90c6142d5571db98af6714");
            captcha.SetUrl("https://www.keycaptcha.ru/demo-magnetic/");
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
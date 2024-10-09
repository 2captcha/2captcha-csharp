using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class FunCaptchaOptionsExample
    {
        public FunCaptchaOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            FunCaptcha captcha = new FunCaptcha();
            captcha.SetSiteKey("69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC");
            captcha.SetUrl("https://mysite.com/page/with/funcaptcha");
            captcha.SetSUrl("https://client-api.arkoselabs.com");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36");
            captcha.SetData("anyKey", "anyValue");
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
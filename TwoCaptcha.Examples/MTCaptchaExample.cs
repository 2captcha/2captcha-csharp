using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class MTCaptchaExample
    {
        public MTCaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            MTCaptcha mtCaptcha = new MTCaptcha();
            mtCaptcha.SetSiteKey("MTPublic-KzqLY1cKH");
            mtCaptcha.SetPageUrl("https://2captcha.com/demo/mtcaptcha");

            try
            {
                solver.Solve(mtCaptcha).Wait();
                Console.WriteLine("Captcha solved: " + mtCaptcha.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }
    }
}


/*
 {
    "key":"YOUR_API_KEY",
    "method":"mt_captcha",
    "sitekey":"MTPublic-KzqLY1cKH",
    "pageurl":"https://2captcha.com/demo/mtcaptcha",
    "json": 1
}*/
 
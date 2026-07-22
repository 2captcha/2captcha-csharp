using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GenericCaptchaExample
    {
        public GenericCaptchaExample(string apiKey)
        {
            //Text captcha example
            GenericTwoCaptcha solver = new GenericTwoCaptcha(apiKey);
            
            GenericCaptcha captcha = new GenericCaptcha();
            captcha.parameters["method"] = "post";
            captcha.parameters["textcaptcha"] = "If tomorrow is Saturday, what day is today?";
            captcha.parameters["lang"] = "en";
            
            //Normal captcha example
            /*
            GenericCaptcha captcha = new GenericCaptcha();
            captcha.parameters["method"] = "base64";
            byte[] bytes = System.IO.File.ReadAllBytes("resources/normal.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);
            captcha.parameters["body"] = base64EncodedImage;
            */

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

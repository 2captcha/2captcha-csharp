using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class NormalOptionsExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            Normal captcha = new Normal();
            captcha.SetFile("../../resources/normal_2.jpg");
            captcha.SetNumeric(4);
            captcha.SetMinLen(4);
            captcha.SetMaxLen(20);
            captcha.SetPhrase(true);
            captcha.SetCaseSensitive(true);
            captcha.SetCalc(false);
            captcha.SetLang("en");
            captcha.SetHintImg(new FileInfo("../../resources/normal_hint.jpg"));
            captcha.SetHintText("Type red symbols only");

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
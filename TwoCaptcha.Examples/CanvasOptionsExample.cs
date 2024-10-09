using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CanvasOptionsExample
    {
        public CanvasOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Canvas captcha = new Canvas();
            captcha.SetFile("resources/canvas.jpg");
            captcha.SetPreviousId(0);
            captcha.SetCanSkip(false);
            captcha.SetLang("en");
            captcha.SetHintImg(new FileInfo("resources/canvas_hint.jpg"));
            captcha.SetHintText("Draw around apple");

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
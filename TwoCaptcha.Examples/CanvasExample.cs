using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CanvasExample
    {
        public CanvasExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Canvas captcha = new Canvas();
            captcha.SetFile("resources/canvas.jpg");
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
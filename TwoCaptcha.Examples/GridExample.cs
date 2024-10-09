using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GridExample
    {
        public GridExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Grid captcha = new Grid("resources/grid.jpg");
            captcha.SetHintText("Select all images with an Orange");

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
using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CoordinatesExample
    {
        public CoordinatesExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Coordinates captcha = new Coordinates("resources/grid.jpg");

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
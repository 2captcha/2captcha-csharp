using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class NormalExample
    {
        public static void Main()
        {
            var solver = new TwoCaptcha("YOUR_API_KEY");

            Normal captcha = new Normal("../../resources/normal.jpg");

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
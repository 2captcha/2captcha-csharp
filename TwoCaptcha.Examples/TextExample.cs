using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class TextExample
    {
        public TextExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey/*, 1*/);

            Text captcha = new Text("If tomorrow is Saturday, what day is today?");

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
using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GridBase64Example
    {
        public GridBase64Example(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            byte[] bytes = File.ReadAllBytes("resources/grid.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);

            Grid captcha = new Grid();
            captcha.SetBase64(base64EncodedImage);
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
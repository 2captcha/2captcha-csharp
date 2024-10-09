using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class GridOptionsExample
    {
        public GridOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            Grid captcha = new Grid();
            captcha.SetFile("resources/grid_2.jpg");
            captcha.SetRows(3);
            captcha.SetCols(3);
            captcha.SetPreviousId(0);
            captcha.SetCanSkip(false);
            captcha.SetLang("en");
            captcha.SetHintImg(new FileInfo("resources/grid_hint.jpg"));
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
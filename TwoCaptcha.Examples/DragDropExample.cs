using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class DragDropExample
    {
        public DragDropExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            DragDrop captcha = new DragDrop();
            captcha.SetFile("resources/grid.jpg");
            captcha.SetImages(new List<string>
            {
                Convert.ToBase64String(File.ReadAllBytes("resources/grid_2.jpg")),
                Convert.ToBase64String(File.ReadAllBytes("resources/normal.jpg"))
            });
            captcha.SetHintText("Drag the images to proper position");

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

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
            captcha.SetFile("resources/dragdrop/drag_drop_main.jpeg");
            captcha.SetImages(new List<string>
            {
                Convert.ToBase64String(File.ReadAllBytes("resources/dragdrop/drag_drop_image1.jpeg")),
                Convert.ToBase64String(File.ReadAllBytes("resources/dragdrop/drag_drop_image2.jpeg"))
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

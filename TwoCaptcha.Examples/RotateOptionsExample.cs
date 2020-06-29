using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class RotateOptionsExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            var images = new List<FileInfo>();
            images.Add(new FileInfo("../../resources/rotate.jpg"));
            images.Add(new FileInfo("../../resources/rotate_2.jpg"));
            images.Add(new FileInfo("../../resources/rotate_3.jpg"));

            Rotate captcha = new Rotate();
            captcha.SetFiles(images);
            captcha.SetAngle(40);
            captcha.SetLang("en");
            captcha.SetHintImg(new FileInfo("../../resources/rotate_hint.jpg"));
            captcha.SetHintText("Put the images in the correct way up");

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
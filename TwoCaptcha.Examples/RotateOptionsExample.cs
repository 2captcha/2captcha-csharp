using System;
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

            byte[] bytes = File.ReadAllBytes("../../resources/rotate.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);


            Rotate captcha = new Rotate();
            captcha.SetBase64(base64EncodedImage);
            captcha.SetAngle(40);
            captcha.SetLang("en");
            captcha.SetHintImg(new FileInfo("../../resources/rotate.jpg"));
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
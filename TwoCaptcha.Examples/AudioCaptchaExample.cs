using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    internal class AudioCaptchaExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            byte[] bytes = File.ReadAllBytes("../../resources/audio-en.mp3");
            string base64EncodedImage = Convert.ToBase64String(bytes);

            AudioCaptcha captcha = new AudioCaptcha();
            captcha.SetBase64(base64EncodedImage);

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

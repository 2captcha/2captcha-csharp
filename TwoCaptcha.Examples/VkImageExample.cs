using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class VkImageExample
    {
        public VkImageExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            byte[] bytes = File.ReadAllBytes("resources/vk.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);
            Console.WriteLine("base64EncodedImage: " + base64EncodedImage);


            VkImage captcha = new VkImage();
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
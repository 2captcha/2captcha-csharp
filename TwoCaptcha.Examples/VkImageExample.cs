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
            captcha.SetSteps("[5,12,22,24,21,23,10,7,2,8,19,18,8,24,21,22,11,14,16,5,18,20,4,21,12,6,0,0,11,12,8,20,19,3,14,8,9,13,16,24,18,3,2,23,8,12,6,1,11,0,20,15,19,22,17,24,8,0,12,5,19,14,11,6,7,14,23,24,23,20,4,20,6,12,4,17,4,18,6,20,17,5,23,7,10,2,8,9,5,4,17,24,11,14,4,10,12,22,21,2]");

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
using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;
using static System.Net.Mime.MediaTypeNames;

namespace TwoCaptcha.Examples
{
    public class VkExample
    {
        public VkExample(string apiKey)
        {
            VkImageExample(apiKey);
            //VkCaptchaExample(apiKey);
        }

        private void VkImageExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            byte[] bytes = File.ReadAllBytes("resources/vk.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);

            VkCaptcha captcha = new VkCaptcha("vkimage");
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

        /*
        private void VkCaptchaExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            VkCaptcha captcha = new VkCaptcha("vkcaptcha");

            captcha.SetRedirectUri("https://id.vk.com/not_robot_captcha?domain=vk.com&session_token=eyJ....HGsc5B4LyvjA&variant=popup&blank=1");
            captcha.SetuserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");
            captcha.SetProxy("http", "1.2.3.4");
            try
            {
                solver.Solve(captcha).Wait();
                Console.WriteLine("Captcha solved: " + captcha.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }*/
    }
}
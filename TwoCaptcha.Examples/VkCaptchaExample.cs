using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;
using static System.Net.Mime.MediaTypeNames;

namespace TwoCaptcha.Examples
{
    public class VkCaptchaExample
    {
        public VkCaptchaExample(string apiKey)
        {
            TokenBased(apiKey);
        }

        private void TokenBased(string apiKey)
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
        }
    }
}
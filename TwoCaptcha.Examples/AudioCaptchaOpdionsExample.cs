﻿using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class AudioCaptchaOptionsExample
    {
        public AudioCaptchaOptionsExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            byte[] bytes = File.ReadAllBytes("resources/audio-ru.mp3");
            string base64EncodedImage = Convert.ToBase64String(bytes);

            AudioCaptcha captcha = new AudioCaptcha();
            captcha.SetBase64(base64EncodedImage);
            captcha.SetLang("ru");

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

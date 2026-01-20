using System;
using System.IO;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class TemuExample
    {
        public TemuExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            byte[] bodyBytes = File.ReadAllBytes("resources/temu/body.png");
            string bodyStr = Convert.ToBase64String(bodyBytes);

            byte[] part1Bytes = File.ReadAllBytes("resources/temu/part1.png");
            string part1Str = Convert.ToBase64String(part1Bytes);

            byte[] part2Bytes = File.ReadAllBytes("resources/temu/part2.png");
            string part2Str = Convert.ToBase64String(part2Bytes);

            byte[] part3Bytes = File.ReadAllBytes("resources/temu/part3.png");
            string part3Str = Convert.ToBase64String(part3Bytes);

            Temu captcha = new Temu();
            captcha.SetBody(bodyStr);
            captcha.SetPart1(part1Str);
            captcha.SetPart2(part2Str);
            captcha.SetPart3(part3Str);

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
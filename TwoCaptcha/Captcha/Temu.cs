using System;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Temu : Captcha
    {
        public Temu() : base()
        {
            parameters["method"] = "temuimage";
        }

        public void SetBody(String body)
        {
            parameters["body"] = body;
        }
        public void SetPart1(String part1)
        {
            parameters["part1"] = part1;
        }
        public void SetPart2(String part2)
        {
            parameters["part2"] = part2;
        }
        public void SetPart3(String part3)
        {
            parameters["part3"] = part3;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class TemuTest : AbstractWrapperTestCase
    {

        [Test]
        public async Task TestAllParameters()
        {
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

            
            var parameters = new Dictionary<string, string>();
            parameters["method"] = "temuimage";
            parameters["body"] = bodyStr;
            parameters["part1"] = part1Str;
            parameters["part2"] = part2Str;
            parameters["part3"] = part3Str;
            parameters["soft_id"] = "4582";


            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class RotateTest : AbstractWrapperTestCase
    {

        [Test]
        public async Task TestAllParameters()
        {
            byte[] bytes = File.ReadAllBytes("../../../resources/rotate.jpg");
            string base64EncodedImage = Convert.ToBase64String(bytes);


            Rotate captcha = new Rotate();
            captcha.SetBase64(base64EncodedImage);
            captcha.SetAngle(45);
            captcha.SetLang("en");
            captcha.SetHintText("Put the images in the correct way up");


            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";
            parameters["angle"] = "45";
            parameters["lang"] = "en";
            parameters["textinstructions"] = "Put the images in the correct way up";
            parameters["body"] = base64EncodedImage;
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

    }
}
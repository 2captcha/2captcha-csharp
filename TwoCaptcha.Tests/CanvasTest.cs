using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class CanvasTest : AbstractWrapperTestCase
    {
        private string captchaImgPath = "../../../resources/canvas.jpg";
        private string hintImgPath = "../../../resources/canvas_hint.jpg";
        private string hintText = "Draw around apple";

        [Test]
        public async Task TestSingleFile()
        {
            FileInfo image = new FileInfo(captchaImgPath);
            
            Console.WriteLine(image.FullName);

            Canvas captcha = new Canvas();
            captcha.SetFile(image);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["recaptcha"] = "1";
            parameters["canvas"] = "1";
            parameters["textinstructions"] = hintText;

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestBase64()
        {
            Canvas captcha = new Canvas();
            captcha.SetBase64("...");
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "base64";
            parameters["recaptcha"] = "1";
            parameters["canvas"] = "1";
            parameters["body"] = "...";
            parameters["textinstructions"] = hintText;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestAllParameters()
        {
            FileInfo image = new FileInfo(captchaImgPath);
            FileInfo hintImg = new FileInfo(hintImgPath);

            Canvas captcha = new Canvas();
            captcha.SetFile(image);
            captcha.SetPreviousId(0);
            captcha.SetCanSkip(false);
            captcha.SetLang("en");
            captcha.SetHintImg(hintImg);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["recaptcha"] = "1";
            parameters["canvas"] = "1";
            parameters["previousID"] = "0";
            parameters["can_no_answer"] = "0";
            parameters["lang"] = "en";
            parameters["textinstructions"] = hintText;

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;
            files["imginstructions"] = hintImg;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }
    }
}
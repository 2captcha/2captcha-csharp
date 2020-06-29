using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class CoordinatesTest : AbstractWrapperTestCase
    {
        private string captchaImgPath = "../../../resources/grid.jpg";
        private string hintImgPath = "../../../resources/grid_hint.jpg";
        private string hintText = "Select all images with an Orange";

        [Test]
        public async Task TestSingleFile()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Coordinates captcha = new Coordinates(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["coordinatescaptcha"] = "1";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestSingleFileParameter()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Coordinates captcha = new Coordinates();
            captcha.SetFile(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["coordinatescaptcha"] = "1";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestBase64()
        {
            Coordinates captcha = new Coordinates();
            captcha.SetBase64("...");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "base64";
            parameters["coordinatescaptcha"] = "1";
            parameters["body"] = "...";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestAllParameters()
        {
            FileInfo image = new FileInfo(captchaImgPath);
            FileInfo hintImg = new FileInfo(hintImgPath);

            Coordinates captcha = new Coordinates();
            captcha.SetFile(image);
            captcha.SetLang("en");
            captcha.SetHintImg(hintImg);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["coordinatescaptcha"] = "1";
            parameters["lang"] = "en";
            parameters["textinstructions"] = hintText;

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;
            files["imginstructions"] = hintImg;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class NormalTest : AbstractWrapperTestCase
    {
        private string captchaImgPath = "../../../resources/normal.jpg";
        private string hintImgPath = "../../../resources/grid_hint.jpg";
        private string hintText = "Type red symbols only";

        [Test]
        public async Task TestSingleFile()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Normal captcha = new Normal(captchaImgPath);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestSingleFileParameter()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Normal captcha = new Normal();
            captcha.SetFile(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestBase64()
        {
            Normal captcha = new Normal();
            captcha.SetBase64("...");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "base64";
            parameters["body"] = "...";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestAllParameters()
        {
            FileInfo image = new FileInfo(captchaImgPath);
            FileInfo hintImg = new FileInfo(hintImgPath);

            Normal captcha = new Normal();
            captcha.SetFile(image);
            captcha.SetNumeric(4);
            captcha.SetMinLen(5);
            captcha.SetMaxLen(20);
            captcha.SetPhrase(true);
            captcha.SetCaseSensitive(true);
            captcha.SetCalc(false);
            captcha.SetLang("en");
            captcha.SetHintImg(hintImg);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["numeric"] = "4";
            parameters["min_len"] = "5";
            parameters["max_len"] = "20";
            parameters["phrase"] = "1";
            parameters["regsense"] = "1";
            parameters["calc"] = "0";
            parameters["lang"] = "en";
            parameters["textinstructions"] = hintText;

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;
            files["imginstructions"] = hintImg;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }
    }
}
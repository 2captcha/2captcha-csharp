using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class GridTest : AbstractWrapperTestCase
    {
        private string captchaImgPath = "../../../resources/grid.jpg";
        private string hintImgPath = "../../../resources/grid_hint.jpg";
        private string hintText = "Select all images with an Orange";

        [Test]
        public async Task TestSingleFile()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Grid captcha = new Grid(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["recaptcha"] = "1";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestSingleFileParameter()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            Grid captcha = new Grid();
            captcha.SetFile(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["recaptcha"] = "1";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestBase64()
        {
            Grid captcha = new Grid();
            captcha.SetBase64("...");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "base64";
            parameters["body"] = "...";
            parameters["recaptcha"] = "1";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestAllParameters()
        {
            FileInfo image = new FileInfo(captchaImgPath);
            FileInfo hintImg = new FileInfo(hintImgPath);

            Grid captcha = new Grid();
            captcha.SetFile(image);
            captcha.SetRows(3);
            captcha.SetCols(3);
            captcha.SetPreviousId(0);
            captcha.SetCanSkip(false);
            captcha.SetLang("en");
            captcha.SetHintImg(hintImg);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "post";
            parameters["recaptcha"] = "1";
            parameters["recaptcharows"] = "3";
            parameters["recaptchacols"] = "3";
            parameters["previousID"] = "0";
            parameters["can_no_answer"] = "0";
            parameters["lang"] = "en";
            parameters["textinstructions"] = hintText;
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;
            files["imginstructions"] = hintImg;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }
    }
}
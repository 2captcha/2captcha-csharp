using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class DragDropTest : AbstractWrapperTestCase
    {
        private string captchaImgPath = "../../../resources/grid.jpg";
        private List<string> images = new List<string> { "img1base64", "img2base64" };

        [Test]
        public async Task TestFile()
        {
            FileInfo image = new FileInfo(captchaImgPath);

            DragDrop captcha = new DragDrop();
            captcha.SetFile(image);
            captcha.SetImages(images);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "drag_drop";
            parameters["images"] = JsonConvert.SerializeObject(images);
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            var files = new Dictionary<string, FileInfo>();
            files["file"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestBase64()
        {
            DragDrop captcha = new DragDrop();
            captcha.SetBase64("...");
            captcha.SetImages(images);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "drag_drop";
            parameters["body"] = "...";
            parameters["images"] = JsonConvert.SerializeObject(images);
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestAllParameters()
        {
            DragDrop captcha = new DragDrop();
            captcha.SetBase64("...");
            captcha.SetImages(images);
            captcha.SetLang("en");
            captcha.SetHintText("Drag the images to proper position");
            captcha.SetHeaderAcao(1);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "drag_drop";
            parameters["body"] = "...";
            parameters["images"] = JsonConvert.SerializeObject(images);
            parameters["lang"] = "en";
            parameters["textinstructions"] = "Drag the images to proper position";
            parameters["header_acao"] = "1";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}

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
        private string[] captchaImgPaths =
        {
            "../../../resources/rotate.jpg",
            "../../../resources/rotate_2.jpg",
            "../../../resources/rotate_3.jpg",
        };

        private string hintImgPath = "../../../resources/grid_hint.jpg";
        private string hintText = "Put the images in the correct way up";

        [Test]
        public async Task TestSingleFile()
        {
            FileInfo image = new FileInfo(captchaImgPaths[0]);

            Rotate captcha = new Rotate(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";

            var files = new Dictionary<string, FileInfo>();
            files["file_1"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestSingleFileParameter()
        {
            FileInfo image = new FileInfo(captchaImgPaths[0]);

            Rotate captcha = new Rotate();
            captcha.SetFile(image);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";
            
            var files = new Dictionary<string, FileInfo>();
            files["file_1"] = image;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestFilesList()
        {
            var images = GetImages();

            Rotate captcha = new Rotate(images);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";
            
            var files = new Dictionary<string, FileInfo>();
            files["file_1"] = images[0];
            files["file_2"] = images[1];
            files["file_3"] = images[2];

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestFilesListParameter()
        {
            var images = GetImages();

            Rotate captcha = new Rotate();
            captcha.SetFiles(images);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";

            var files = new Dictionary<string, FileInfo>();
            files["file_1"] = images[0];
            files["file_2"] = images[1];
            files["file_3"] = images[2];

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        [Test]
        public async Task TestAllParameters()
        {
            FileInfo image = new FileInfo(captchaImgPaths[0]);
            FileInfo hintImg = new FileInfo(hintImgPath);

            Rotate captcha = new Rotate();
            captcha.SetFile(image);
            captcha.SetAngle(45);
            captcha.SetLang("en");
            captcha.SetHintImg(hintImg);
            captcha.SetHintText(hintText);

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "rotatecaptcha";
            parameters["angle"] = "45";
            parameters["lang"] = "en";
            parameters["textinstructions"] = hintText;

            var files = new Dictionary<string, FileInfo>();
            files["file_1"] = image;
            files["imginstructions"] = hintImg;

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        private List<FileInfo> GetImages()
        {
            var images = new List<FileInfo>();

            foreach (string image in captchaImgPaths)
            {
                images.Add(new FileInfo(image));
            }

            return images;
        }
    }
}
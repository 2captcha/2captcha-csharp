using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class MTCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            MTCaptcha mtCaptcha = new MTCaptcha();
            mtCaptcha.SetSiteKey("MTPublic-KzqLY1cKH");
            mtCaptcha.SetPageUrl("https://2captcha.com/demo/mtcaptcha");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "mt_captcha";
            parameters["sitekey"] = "MTPublic-KzqLY1cKH";
            parameters["pageurl"] = "https://2captcha.com/demo/mtcaptcha";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(mtCaptcha, parameters);
        }
    }
}
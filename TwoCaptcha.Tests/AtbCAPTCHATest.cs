using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class AtbCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            AtbCAPTCHA atbCAPTCHA = new AtbCAPTCHA();
            atbCAPTCHA.SetAppId("af23e041b22d000a11e22a230fa8991c");
            atbCAPTCHA.SetApiServer("https://cap.aisecurius.com");
            atbCAPTCHA.SetPageUrl("https://www.example.com/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "atb_captcha";
            parameters["app_id"] = "af23e041b22d000a11e22a230fa8991c";
            parameters["api_server"] = "https://cap.aisecurius.com";
            parameters["pageurl"] = "https://www.example.com/";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(atbCAPTCHA, parameters);
        }
    }
}
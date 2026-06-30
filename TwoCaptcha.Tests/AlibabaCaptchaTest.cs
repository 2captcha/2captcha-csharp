using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class AlibabaCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            AlibabaCaptcha captcha = new AlibabaCaptcha();
            captcha.SetSceneId("login");
            captcha.SetPrefix("https://img.alicdn.com/tfs/...");
            captcha.SetPageUrl("https://example.com/page-with-alibaba");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "alibaba";
            parameters["scene_id"] = "login";
            parameters["prefix"] = "https://img.alicdn.com/tfs/...";
            parameters["pageurl"] = "https://example.com/page-with-alibaba";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}

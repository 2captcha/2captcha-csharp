using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class GeeTestV4Test : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            GeeTestV4 captcha = new GeeTestV4();
            captcha.SetCaptchaId("72bf15796d0b69c43867452fea615052");
            captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
            captcha.SetUrl("https://mysite.com/captcha.html");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "geetest_v4";
            parameters["captcha_id"] = "72bf15796d0b69c43867452fea615052";
            parameters["challenge"] = "12345678abc90123d45678ef90123a456b";
            parameters["pageurl"] = "https://mysite.com/captcha.html";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
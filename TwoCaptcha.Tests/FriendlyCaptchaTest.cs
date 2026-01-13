using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class FriendlyCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            FriendlyCaptcha captcha = new FriendlyCaptcha();
            captcha.SetSiteKey("2FZFEVS1FZCGQ9");
            captcha.SetUrl("https://www.site.com/page/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "friendly_captcha";
            parameters["sitekey"] = "2FZFEVS1FZCGQ9";
            parameters["pageurl"] = "https://www.site.com/page/";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
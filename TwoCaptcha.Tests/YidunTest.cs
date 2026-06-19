using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class YidunTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Yidun captcha = new Yidun();
            captcha.SetSiteKey("0f743r3g1...8rz3grz0ym5");
            captcha.SetPageUrl("https://example.com/page-with-yidun"); ;

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "yidun";
            parameters["sitekey"] = "0f743r3g1...8rz3grz0ym5";
            parameters["pageurl"] = "https://example.com/page-with-yidun";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
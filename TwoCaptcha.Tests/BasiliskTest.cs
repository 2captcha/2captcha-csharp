using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class BasiliskTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Basilisk captcha = new Basilisk();
            captcha.SetSiteKey("b7890h...19fb2600897");
            captcha.SetUrl("https://example.com/login");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36");
            captcha.SetProxy("HTTPS", "login:password@1.2.3.4:5678");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "basilisk";
            parameters["sitekey"] = "b7890h...19fb2600897";
            parameters["pageurl"] = "https://example.com/login";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36";
            parameters["proxy"] = "login:password@1.2.3.4:5678";
            parameters["proxytype"] = "HTTPS";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}

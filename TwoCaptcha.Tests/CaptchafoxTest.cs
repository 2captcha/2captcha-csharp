using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class CaptchafoxTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Captchafox captcha = new Captchafox();
            captcha.SetSiteKey("sk_ILKWNruBBVKDOM7dZs59KHnDLEWiH");
            captcha.SetUrl("https://mysite.com/page/with/captchafox");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
            captcha.SetProxy("HTTPS", "username:password@1.2.3.4:5678");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "captchafox";
            parameters["sitekey"] = "sk_ILKWNruBBVKDOM7dZs59KHnDLEWiH";
            parameters["pageurl"] = "https://mysite.com/page/with/captchafox";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36";
            parameters["proxy"] = "username:password@1.2.3.4:5678";
            parameters["proxytype"] = "HTTPS";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
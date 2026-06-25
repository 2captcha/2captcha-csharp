using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class HuntTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Hunt captcha = new Hunt();
            captcha.SetUrl("https://example.com/page-with-hunt");
            captcha.SetApiGetLib("https://example.com/hd-api/external/apps/app-id/api.js");
            captcha.SetData("meta.token.value");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
            captcha.SetProxy("HTTPS", "login:password@1.2.3.4:5678");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "hunt";
            parameters["pageurl"] = "https://example.com/page-with-hunt";
            parameters["api_get_lib"] = "https://example.com/hd-api/external/apps/app-id/api.js";
            parameters["data"] = "meta.token.value";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36";
            parameters["proxy"] = "login:password@1.2.3.4:5678";
            parameters["proxytype"] = "HTTPS";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}

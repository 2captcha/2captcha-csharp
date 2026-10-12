using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class ImpervaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Imperva captcha = new Imperva();
            captcha.SetPageUrl("https://example.com/login");
            captcha.SetIncapsulaScriptUrl("/_Incapsula_Resource?SWUDNSAI=31&xinfo=1");
            captcha.SetIncapsulaCookies("visid_incap_123456=sample; incap_ses_123_123456=sample");
            captcha.SetReese84UrlEndpoint("https://example.com/_Incapsula_Resource?reese84=1");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36");
            captcha.SetProxy("HTTP", "login:password@1.2.3.4:8080");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "incapsula";
            parameters["pageurl"] = "https://example.com/login";
            parameters["incapsula_script_url"] = "/_Incapsula_Resource?SWUDNSAI=31&xinfo=1";
            parameters["incapsula_cookies"] = "visid_incap_123456=sample; incap_ses_123_123456=sample";
            parameters["reese84_url_endpoint"] = "https://example.com/_Incapsula_Resource?reese84=1";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36";
            parameters["proxy"] = "login:password@1.2.3.4:8080";
            parameters["proxytype"] = "HTTP";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}

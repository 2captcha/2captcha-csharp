using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class FunCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            FunCaptcha captcha = new FunCaptcha();
            captcha.SetSiteKey("69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC");
            captcha.SetUrl("https://mysite.com/page/with/funcaptcha");
            captcha.SetSUrl("https://client-api.arkoselabs.com");
            captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36");
            captcha.SetData("anyKey", "anyStringValue");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "funcaptcha";
            parameters["publickey"] = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC";
            parameters["pageurl"] = "https://mysite.com/page/with/funcaptcha";
            parameters["surl"] = "https://client-api.arkoselabs.com";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36";
            parameters["data[anyKey]"] = "anyStringValue";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
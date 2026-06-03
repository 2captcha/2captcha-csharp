using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class BinanceCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            BinanceCaptcha captcha = new BinanceCaptcha();
            captcha.SetSiteKey("login");
            captcha.SetPageUrl("https://example.com/page-with-binance");
            captcha.SetValidateId("cb0bfef...e54ecd57b");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "binance";
            parameters["sitekey"] = "login";
            parameters["pageurl"] = "https://example.com/page-with-binance";
            parameters["validate_id"] = "cb0bfef...e54ecd57b";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
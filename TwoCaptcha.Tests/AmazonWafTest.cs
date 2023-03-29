using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class AmazonWafTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            AmazonWaf captcha = new AmazonWaf();
            captcha.SetSiteKey("AQIDAHjcYu/GjX+QlghicBgQ/7bFaQZ+m5FKCMDnO+vTbNg96AF5H1K/siwSLK7RfstKtN5bAAAAfjB8BgkqhkiG9w0BBwagbzBtAgEAMGgGCSqGSIb3DQEHATAeBglg");
            captcha.SetUrl("https://non-existent-example.execute-api.us-east-1.amazonaws.com");
            captcha.SetContext("test_iv");
            captcha.SetIV("test_context");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "amazon_waf";
            parameters["sitekey"] = "AQIDAHjcYu/GjX+QlghicBgQ/7bFaQZ+m5FKCMDnO+vTbNg96AF5H1K/siwSLK7RfstKtN5bAAAAfjB8BgkqhkiG9w0BBwagbzBtAgEAMGgGCSqGSIb3DQEHATAeBglg";
            parameters["pageurl"] = "https://non-existent-example.execute-api.us-east-1.amazonaws.com";
            parameters["context"] = "test_iv";
            parameters["iv"] = "test_context";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
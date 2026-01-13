using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    class CutcaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Cutcaptcha cutcaptcha = new Cutcaptcha();
            cutcaptcha.SetMiseryKey("a1488b66da00bf332a1488993a5443c79047e752");
            cutcaptcha.SetPageUrl("https://example.cc/foo/bar.html");
            cutcaptcha.SetApiKey("SAb83IIB");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "cutcaptcha";
            parameters["misery_key"] = "a1488b66da00bf332a1488993a5443c79047e752";
            parameters["pageurl"] = "https://example.cc/foo/bar.html";
            parameters["api_key"] = "SAb83IIB"; 
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(cutcaptcha, parameters);
        }
    }
}
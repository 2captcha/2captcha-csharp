using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class GeeTestTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            GeeTest captcha = new GeeTest();
            captcha.SetGt("f2ae6cadcf7886856696502e1d55e00c");
            captcha.SetApiServer("api-na.geetest.com");
            captcha.SetChallenge("69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC");
            captcha.SetUrl("https://launches.endclothing.com/distil_r_captcha.html");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "geetest";
            parameters["gt"] = "f2ae6cadcf7886856696502e1d55e00c";
            parameters["api_server"] = "api-na.geetest.com";
            parameters["challenge"] = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC";
            parameters["pageurl"] = "https://launches.endclothing.com/distil_r_captcha.html";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class TurnstileTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Turnstile captcha = new Turnstile();
            captcha.SetSiteKey("0x4AAAAAAAChNiVJM_WtShFf");
            captcha.SetUrl("https://ace.fusionist.io");
            captcha.SetData("foo");
            captcha.SetPageData("bar");
            captcha.SetAction("baz");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "turnstile";
            parameters["sitekey"] = "0x4AAAAAAAChNiVJM_WtShFf";
            parameters["pageurl"] = "https://ace.fusionist.io";
            parameters["data"] = "foo";
            parameters["pagedata"] = "bar";
            parameters["action"] = "baz";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
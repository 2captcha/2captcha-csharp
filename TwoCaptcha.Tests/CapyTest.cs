using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class CapyTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Capy captcha = new Capy();
            captcha.SetSiteKey("PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v");
            captcha.SetUrl("http://mysite.com/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "capy";
            parameters["captchakey"] = "PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v";
            parameters["pageurl"] = "http://mysite.com/";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
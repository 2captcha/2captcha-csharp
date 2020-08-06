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
            captcha.SetApiServer("https://myapiserver.com/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "capy";
            parameters["captchakey"] = "PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v";
            parameters["pageurl"] = "http://mysite.com/";
            parameters["api_server"] = "https://myapiserver.com/";


            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class ProsopoTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Prosopo captcha = new Prosopo();
            captcha.SetSiteKey("5EZVvsHMrKCFKp5NYNoTyDjTjetoVo1Z4UNNbTwJf1GfN6Xm");
            captcha.SetUrl("https://www.twickets.live/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "prosopo";
            parameters["sitekey"] = "5EZVvsHMrKCFKp5NYNoTyDjTjetoVo1Z4UNNbTwJf1GfN6Xm";
            parameters["pageurl"] = "https://www.twickets.live/";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
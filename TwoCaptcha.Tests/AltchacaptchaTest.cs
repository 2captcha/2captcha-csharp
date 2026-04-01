using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class AltchacaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Altchacaptcha captcha = new Altchacaptcha();
            captcha.SetChallengeUrl("https://.../captcha/api/altcha/challenge");
            captcha.SetPageUrl("https://site.com/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "altcha";
            parameters["challenge_url"] = "https://.../captcha/api/altcha/challenge";
            parameters["pageurl"] = "https://site.com/";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
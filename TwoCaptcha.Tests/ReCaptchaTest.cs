using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class ReCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestV2()
        {
            ReCaptcha captcha = new ReCaptcha();
            captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
            captcha.SetUrl("https://mysite.com/page/with/recaptcha");
            captcha.SetInvisible(true);
            captcha.SetAction("verify");
            captcha.SetDomain("recaptcha.net");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "userrecaptcha";
            parameters["googlekey"] = "6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-";
            parameters["pageurl"] = "https://mysite.com/page/with/recaptcha";
            parameters["invisible"] = "1";
            parameters["action"] = "verify";
            parameters["domain"] = "recaptcha.net";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }

        [Test]
        public async Task TestV3()
        {
            ReCaptcha captcha = new ReCaptcha();
            captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
            captcha.SetUrl("https://mysite.com/page/with/recaptcha");
            captcha.SetVersion("v3");
            captcha.SetAction("verify");
            captcha.SetScore(0.3);
            captcha.SetDomain("recaptcha.net");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "userrecaptcha";
            parameters["googlekey"] = "6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-";
            parameters["pageurl"] = "https://mysite.com/page/with/recaptcha";
            parameters["version"] = "v3";
            parameters["action"] = "verify";
            parameters["min_score"] = "0.3";
            parameters["domain"] = "recaptcha.net";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
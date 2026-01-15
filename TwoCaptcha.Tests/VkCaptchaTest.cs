using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TwoCaptcha.Captcha;
using static System.Net.Mime.MediaTypeNames;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class VkCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllParameters()
        {
            VkCaptcha captcha = new VkCaptcha("vkcaptcha");
            captcha.SetSiteKey("0x4AAAAAAAChNiVJM_WtShFf");
            captcha.SetUrl("https://ace.fusionist.io");
            
            var parameters = new Dictionary<string, string>();
            parameters["method"] = "vkcaptcha";
            parameters["soft_id"] = "4582";
            parameters["pageurl"] = "https://ace.fusionist.io";
            parameters["sitekey"] = "0x4AAAAAAAChNiVJM_WtShFf";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
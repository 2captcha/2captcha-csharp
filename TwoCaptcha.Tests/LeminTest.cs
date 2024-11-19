using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class LeminTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Lemin captcha = new Lemin();
            captcha.SetCaptchaId("CROPPED_d3d4d56_73ca4008925b4f83a8bed59c2dd0df6d");
            captcha.SetApiServer("api.leminnow.com");
            captcha.SetUrl("http://sat2.aksigorta.com.tr");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "lemin";
            parameters["captcha_id"] = "CROPPED_d3d4d56_73ca4008925b4f83a8bed59c2dd0df6d";
            parameters["api_server"] = "api.leminnow.com";
            parameters["pageurl"] = "http://sat2.aksigorta.com.tr";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
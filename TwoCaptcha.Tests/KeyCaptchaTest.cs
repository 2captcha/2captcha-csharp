using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class KeyCaptchaTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            KeyCaptcha captcha = new KeyCaptcha();
            captcha.SetUserId(10);
            captcha.SetSessionId("493e52c37c10c2bcdf4a00cbc9ccd1e8");
            captcha.SetWebServerSign("9006dc725760858e4c0715b835472f22-pz-");
            captcha.SetWebServerSign2("2ca3abe86d90c6142d5571db98af6714");
            captcha.SetUrl("https://www.keycaptcha.ru/demo-magnetic/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "keycaptcha";
            parameters["s_s_c_user_id"] = "10";
            parameters["s_s_c_session_id"] = "493e52c37c10c2bcdf4a00cbc9ccd1e8";
            parameters["s_s_c_web_server_sign"] = "9006dc725760858e4c0715b835472f22-pz-";
            parameters["s_s_c_web_server_sign2"] = "2ca3abe86d90c6142d5571db98af6714";
            parameters["pageurl"] = "https://www.keycaptcha.ru/demo-magnetic/";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
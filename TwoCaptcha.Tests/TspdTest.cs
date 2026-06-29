using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class TspdTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Tspd captcha = new Tspd();
            captcha.SetPageUrl("https://example.com/login");
            captcha.SetTspdCookie("TS386a400d029=082670...010245; TS386a400d078=082670...dbb3b0c");
            captcha.SetHtmlPageBase64("PCFET0NUWVBFIGh0bWw+...");
            captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "tspd";
            parameters["pageurl"] = "https://example.com/login";
            parameters["tspd_cookie"] = "TS386a400d029=082670...010245; TS386a400d078=082670...dbb3b0c";
            parameters["html_page_base64"] = "PCFET0NUWVBFIGh0bWw+...";
            parameters["proxytype"] = "HTTPS";
            parameters["proxy"] = "login:password@IP_address:PORT";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters);
        }
    }
}
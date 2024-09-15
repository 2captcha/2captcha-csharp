using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class TencentTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            Tencent tencent = new Tencent();
            tencent.SetAppId("190014885");
            tencent.SetPageUrl("https://www.example.com/");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "tencent";
            parameters["app_id"] = "190014885";
            parameters["pageurl"] = "https://www.example.com/";
            parameters["soft_id"] = "4582";

            await CheckIfCorrectParamsSendAndResultReturned(tencent, parameters);
        }
    }
}
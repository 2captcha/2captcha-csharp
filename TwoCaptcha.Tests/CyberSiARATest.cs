using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Tests
{
    class CyberSiARATest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            CyberSiARA cyberSiARA = new CyberSiARA();
            cyberSiARA.SetMasterUrlId("tpjOCKjjpdzv3d8Ub2E9COEWKt1vl1Mv");
            cyberSiARA.SetPageUrl("https://demo.mycybersiara.com/");
            cyberSiARA.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "cybersiara";
            parameters["master_url_id"] = "tpjOCKjjpdzv3d8Ub2E9COEWKt1vl1Mv";
            parameters["pageurl"] = "https://demo.mycybersiara.com/";
            parameters["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36";
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(cyberSiARA, parameters);
        }
    }
}
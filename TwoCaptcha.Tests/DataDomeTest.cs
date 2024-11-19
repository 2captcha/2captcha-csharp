using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TwoCaptcha.Captcha;
using static System.Net.WebRequestMethods;

namespace TwoCaptcha.Tests
{
    [TestFixture]
    public class DataDomeTest : AbstractWrapperTestCase
    {
        [Test]
        public async Task TestAllOptions()
        {
            DataDome dataDome = new DataDome();
            dataDome.SetCapthaUrl("https://geo.captcha-delivery.com/captcha/?initialCid=AHrlqAAA...P~XFrBVptk&t=fe&referer=https%3A%2F%2Fhexample.com&s=45239&e=c538be..c510a00ea");
            dataDome.SetPageUrl("https://example.com/");
            dataDome.SetProxy("http", "username:password@1.2.3.4:5678");
            dataDome.SetUserAgent("Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Mobile Safari/537.3");

            var parameters = new Dictionary<string, string>();
            parameters["method"] = "datadome";
            parameters["captcha_url"] = "https://geo.captcha-delivery.com/captcha/?initialCid=AHrlqAAA...P~XFrBVptk&t=fe&referer=https%3A%2F%2Fhexample.com&s=45239&e=c538be..c510a00ea";
            parameters["pageurl"] = "https://example.com/";
            parameters["proxy"] = "https://example.com/";            
            parameters["proxy"] = "username:password@1.2.3.4:5678";
            parameters["proxytype"] = "http";
            parameters["userAgent"] = "Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Mobile Safari/537.3"; 
            parameters["soft_id"] = "4582";
            parameters["json"] = "0";

            await CheckIfCorrectParamsSendAndResultReturned(dataDome, parameters);
        }
    }
}
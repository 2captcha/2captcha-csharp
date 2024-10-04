using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class CyberSiARAExample
    {
        public CyberSiARAExample(string apiKey)
        {
            TwoCaptcha solver = new TwoCaptcha(apiKey);

            CyberSiARA cyberSiARA = new CyberSiARA();
            cyberSiARA.SetMasterUrlId("tpjOCKjjpdzv3d8Ub2E9COEWKt1vl1Mv");
            cyberSiARA.SetPageUrl("https://demo.mycybersiara.com/");
            cyberSiARA.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");

            try
            {
                solver.Solve(cyberSiARA).Wait();
                Console.WriteLine("Captcha solved: " + cyberSiARA.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }
    }
}
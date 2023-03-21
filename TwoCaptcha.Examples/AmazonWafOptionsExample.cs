using System;
using System.Linq;
using TwoCaptcha.Captcha;

namespace TwoCaptcha.Examples
{
    public class AmazonWafOptionsExample
    {
        public void Main()
        {
            TwoCaptcha solver = new TwoCaptcha("YOUR_API_KEY");

            AmazonWaf captcha = new AmazonWaf();
            captcha.SetSiteKey("AQIDAHjcYu/GjX+QlghicBgQ/7bFaQZ+m5FKCMDnO+vTbNg96AF5H1K/siwSLK7RfstKtN5bAAAAfjB8BgkqhkiG9w0BBwagbzBtAgEAMGgGCSqGSIb3DQEHATAeBglg");
            captcha.SetUrl("https://non-existent-example.execute-api.us-east-1.amazonaws.com");
            captcha.SetContext("test_iv");
            captcha.SetIV("test_context");
            captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");

            try
            {
                solver.Solve(captcha).Wait();
                Console.WriteLine("Captcha solved: " + captcha.Code);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
            }
        }
    }
}
namespace TwoCaptcha.Captcha
{
    public class AmazonWaf : Captcha
    {
        public AmazonWaf() : base()
        {
            parameters["method"] = "amazon_waf";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["sitekey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetContext(string context)
        {
            parameters["context"] = context;
        }

        public void SetIV(string iv)
        {
            parameters["iv"] = iv;
        }
    }
}
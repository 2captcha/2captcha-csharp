namespace TwoCaptcha.Captcha
{
    public class FunCaptcha : Captcha
    {
        public FunCaptcha() : base()
        {
            parameters["method"] = "funcaptcha";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["publickey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetSUrl(string sUrl)
        {
            parameters["surl"] = sUrl;
        }

        public void SetUserAgent(string userAgent)
        {
            parameters["userAgent"] = userAgent;
        }

        public void SetData(string key, string value)
        {
            parameters["data[" + key + "]"] = value;
        }
    }
}
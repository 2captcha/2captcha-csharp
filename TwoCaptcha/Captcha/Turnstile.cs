namespace TwoCaptcha.Captcha
{
    public class Turnstile : Captcha
    {
        public Turnstile() : base()
        {
            parameters["method"] = "turnstile";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["sitekey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetAction(string action)
        {
            parameters["action"] = action;
        }
        public void SetData(string data)
        {
            parameters["data"] = data;
        }
        public void SetPageData(string pagedata)
        {
            parameters["pagedata"] = pagedata;
        }
    }
}
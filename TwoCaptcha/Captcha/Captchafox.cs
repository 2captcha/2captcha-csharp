namespace TwoCaptcha.Captcha
{
    public class Captchafox : Captcha
    {
        public Captchafox() : base()
        {
            parameters["method"] = "captchafox";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["sitekey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }
    }
}
namespace TwoCaptcha.Captcha
{
    public class FriendlyCaptcha : Captcha
    {
        public FriendlyCaptcha() : base()
        {
            parameters["method"] = "friendly_captcha";
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
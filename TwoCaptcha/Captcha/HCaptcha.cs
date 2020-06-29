namespace TwoCaptcha.Captcha
{
    public class HCaptcha : Captcha
    {
        public HCaptcha() : base()
        {
            parameters["method"] = "hcaptcha";
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
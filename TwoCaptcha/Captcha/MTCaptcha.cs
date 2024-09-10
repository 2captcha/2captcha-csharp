
namespace TwoCaptcha.Captcha
{
    public class MTCaptcha : Captcha
    {
        public MTCaptcha() : base()
        {
            parameters["method"] = "mt_captcha";
        }

        public void SetPageUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["sitekey"] = siteKey;
        }
    }
}

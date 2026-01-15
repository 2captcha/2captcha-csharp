namespace TwoCaptcha.Captcha
{
    public class Prosopo : Captcha
    {
        public Prosopo() : base()
        {
            parameters["method"] = "prosopo";
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
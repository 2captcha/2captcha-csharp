namespace TwoCaptcha.Captcha
{
    public class Capy : Captcha
    {
        public Capy() : base()
        {
            parameters["method"] = "capy";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["captchakey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetApiServer(string apiServer)
        {
            parameters["api_server"] = apiServer;
        }

    }
}
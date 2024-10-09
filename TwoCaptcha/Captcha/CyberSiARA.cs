namespace TwoCaptcha.Captcha
{
    public class CyberSiARA : Captcha
    {
        public CyberSiARA() : base()
        {
            parameters["method"] = "cybersiara";
        }
        public void SetMasterUrlId(string masterUrlId)
        {
            parameters["master_url_id"] = masterUrlId;
        }
        public void SetPageUrl(string pageUrl)
        {
            parameters["pageurl"] = pageUrl;
        }
        public void SetUserAgent(string userAgent)
        {
            parameters["userAgent"] = userAgent;
        }

    }
}

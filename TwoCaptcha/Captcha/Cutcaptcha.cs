namespace TwoCaptcha.Captcha
{
    public class Cutcaptcha : Captcha
    {
        public Cutcaptcha() : base()
        {
            parameters["method"] = "cutcaptcha";
        }
        public void SetMiseryKey(string miseryKey)
        {
            parameters["misery_key"] = miseryKey;
        }
        public void SetApiKey(string apiKey)
        {
            parameters["api_key"] = apiKey;
        }
        public void SetPageUrl(string pageUrl)
        {
            parameters["pageurl"] = pageUrl;
        }
    }
}

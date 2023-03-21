namespace TwoCaptcha.Captcha
{
    public class Yandex : Captcha
    {
        public Yandex() : base()
        {
            parameters["method"] = "yandex";
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

namespace TwoCaptcha.Captcha
{
    public class DataDome : Captcha
    {
        public DataDome() : base()
        {
            parameters["method"] = "datadome";
        }

        public void SetCapthaUrl(string capthaUrl)
        {
            parameters["captcha_url"] = capthaUrl;
        }

        public void SetPageUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetUserAgent(string userAgent)
        {
            parameters["userAgent"] = userAgent;
        }
    }
}

namespace TwoCaptcha.Captcha
{
    public class Tencent : Captcha
    {
        public Tencent() : base()
        {
            parameters["method"] = "tencent ";
        }

        public void SetPageUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetAppId(string appId)
        {
            parameters["app_id"] = appId;
        }
    }
}
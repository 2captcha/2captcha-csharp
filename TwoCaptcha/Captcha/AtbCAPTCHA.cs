
namespace TwoCaptcha.Captcha
{
    public class AtbCAPTCHA : Captcha
    {
        public AtbCAPTCHA() : base()
        {
            parameters["method"] = "atb_captcha";
        }

        public void SetPageUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetApiServer(string apiServer)
        {
            parameters["api_server"] = apiServer;
        }

        public void SetAppId(string appId)
        {
            parameters["app_id"] = appId;
        }
    }
}
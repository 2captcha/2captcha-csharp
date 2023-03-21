namespace TwoCaptcha.Captcha
{
    public class GeeTestV4 : Captcha
    {
        public GeeTestV4() : base()
        {
            parameters["method"] = "geetest_v4";
        }

        public void SetCaptchaId(string captchaId)
        {
            parameters["captcha_id"] = captchaId;
        }

        public void SetChallenge(string challenge)
        {
            parameters["challenge"] = challenge;
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
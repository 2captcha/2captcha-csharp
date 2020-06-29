namespace TwoCaptcha.Captcha
{
    public class GeeTest : Captcha
    {
        public GeeTest() : base()
        {
            parameters["method"] = "geetest";
        }

        public void SetGt(string gt)
        {
            parameters["gt"] = gt;
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
namespace TwoCaptcha.Captcha
{
    public class Lemin : Captcha
    {
        public Lemin() : base()
        {
            parameters["method"] = "lemin";
        }

        public void SetCaptchaId(string captchaid)
        {
            parameters["captcha_id"] = captchaid;
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
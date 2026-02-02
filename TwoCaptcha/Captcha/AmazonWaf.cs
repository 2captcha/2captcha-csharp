namespace TwoCaptcha.Captcha
{
    public class AmazonWaf : Captcha
    {
        public AmazonWaf() : base()
        {
            parameters["method"] = "amazon_waf";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["sitekey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetContext(string context)
        {
            parameters["context"] = context;
        }

        public void SetIV(string iv)
        {
            parameters["iv"] = iv;
        }

        public void SetChallengeScript(string challengeScript)
        {
            parameters["challenge_script"] = challengeScript;
        }

        public void SetCaptchaScript(string captchaScript)
        {
            parameters["captcha_script"] = captchaScript;
        }

        public void SetHeaderAcao(int headerAcao)
        {
            parameters["header_acao"] = headerAcao.ToString();
        }
    }
}
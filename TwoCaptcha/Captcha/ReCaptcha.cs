using System;

namespace TwoCaptcha.Captcha
{
    public class ReCaptcha : Captcha
    {
        public ReCaptcha() : base()
        {
            parameters["method"] = "userrecaptcha";
        }

        public void SetSiteKey(string siteKey)
        {
            parameters["googlekey"] = siteKey;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }

        public void SetInvisible(bool invisible)
        {
            parameters["invisible"] = invisible ? "1" : "0";
        }

        public void SetVersion(string version)
        {
            parameters["version"] = version;
        }

        public void SetAction(string action)
        {
            parameters["action"] = action;
        }

        public void SetDomain(string domain)
        {
            parameters["domain"] = domain;
        }

        public void SetScore(double score)
        {
            parameters["min_score"] = Convert.ToString(score).Replace(',', '.');
        }
    }
}
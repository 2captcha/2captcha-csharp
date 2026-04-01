using System;

namespace TwoCaptcha.Captcha
{
    public class Altchacaptcha : Captcha
    {
        public Altchacaptcha() : base()
        {
            parameters["method"] = "altcha";
        }
        
        public void SetChallengeUrl(string challengeUrl)
        {
            parameters["challenge_url"] = challengeUrl;
        }

        public void SetPageUrl(string pageurl)
        {
            parameters["pageurl"] = pageurl;
        }

        public void SetChallengeJson(string challengeJson)
        {
            parameters["challenge_json"] = challengeJson;
        }                
    }
}
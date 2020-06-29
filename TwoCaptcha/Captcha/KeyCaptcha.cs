using System;

namespace TwoCaptcha.Captcha
{
    public class KeyCaptcha : Captcha
    {
        public KeyCaptcha() : base()
        {
            parameters["method"] = "keycaptcha";
        }

        public void SetUserId(int userId)
        {
            SetUserId(Convert.ToString(userId));
        }

        public void SetUserId(string userId)
        {
            parameters["s_s_c_user_id"] = userId;
        }

        public void SetSessionId(string sessionId)
        {
            parameters["s_s_c_session_id"] = sessionId;
        }

        public void SetWebServerSign(string sign)
        {
            parameters["s_s_c_web_server_sign"] = sign;
        }

        public void SetWebServerSign2(string sign)
        {
            parameters["s_s_c_web_server_sign2"] = sign;
        }

        public void SetUrl(string url)
        {
            parameters["pageurl"] = url;
        }
    }
}
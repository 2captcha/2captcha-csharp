using System;

namespace TwoCaptcha.Captcha
{
    public class AudioCaptcha : Captcha
    {
        public AudioCaptcha() : base()
        {
            parameters["method"] = "audio";
        }
        public void SetBase64(String base64)
        {
            parameters["body"] = base64;
        }
        public void SetLang(String lang)
        {
            parameters["lang"] = lang;
        }
    }
}
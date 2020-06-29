using System;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Canvas : Captcha
    {
        public Canvas() : base()
        {
            parameters["canvas"] = "1";
            parameters["recaptcha"] = "1";
        }

        public void SetFile(string filePath)
        {
            SetFile(new FileInfo(filePath));
        }

        public void SetFile(FileInfo file)
        {
            files["file"] = file;
        }

        public void SetBase64(string base64)
        {
            parameters["body"] = base64;
        }

        public void SetPreviousId(int previousId)
        {
            parameters["previousID"] = Convert.ToString(previousId);
        }

        public void SetCanSkip(bool canSkip)
        {
            parameters["can_no_answer"] = canSkip ? "1" : "0";
        }

        public void SetLang(string lang)
        {
            parameters["lang"] = lang;
        }

        public void SetHintText(string hintText)
        {
            parameters["textinstructions"] = hintText;
        }

        public void SetHintImg(string base64)
        {
            parameters["imginstructions"] = base64;
        }

        public void SetHintImg(FileInfo hintImg)
        {
            files["imginstructions"] = hintImg;
        }
    }
}
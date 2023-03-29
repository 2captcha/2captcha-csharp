using System;
using System.Collections.Generic;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Rotate : Captcha
    {
        public Rotate() : base()
        {
            parameters["method"] = "rotatecaptcha";
        }


        public void SetBase64(String base64)
        {
            parameters["body"] = base64;
        }

        public void SetAngle(double angle)
        {
            parameters["angle"] = Convert.ToString(angle).Replace(',', '.');
        }

        public void SetLang(String lang)
        {
            parameters["lang"] = lang;
        }

        public void SetHintText(String hintText)
        {
            parameters["textinstructions"] = hintText;
        }

        public void SetHintImg(String base64)
        {
            parameters["imginstructions"] = base64;
        }

        public void SetHintImg(FileInfo hintImg)
        {
            files["imginstructions"] = hintImg;
        }
    }
}
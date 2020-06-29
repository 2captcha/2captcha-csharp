using System;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Normal : Captcha
    {
        public Normal() : base()
        {
        }

        public Normal(String filePath) : this(new FileInfo(filePath))
        {
        }

        public Normal(FileInfo file) : this()
        {
            SetFile(file);
        }

        public void SetFile(string filePath)
        {
            SetFile(new FileInfo(filePath));
        }

        public void SetFile(FileInfo file)
        {
            files["file"] = file;
        }

        public void SetBase64(String base64)
        {
            parameters["body"] = base64;
        }

        public void SetPhrase(bool phrase)
        {
            parameters["phrase"] = phrase ? "1" : "0";
        }

        public void SetCaseSensitive(bool caseSensitive)
        {
            parameters["regsense"] = caseSensitive ? "1" : "0";
        }

        public void SetCalc(bool calc)
        {
            parameters["calc"] = calc ? "1" : "0";
        }

        public void SetNumeric(int numeric)
        {
            parameters["numeric"] = Convert.ToString(numeric);
        }

        public void SetMinLen(int length)
        {
            parameters["min_len"] = Convert.ToString(length);
        }

        public void SetMaxLen(int length)
        {
            parameters["max_len"] = Convert.ToString(length);
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
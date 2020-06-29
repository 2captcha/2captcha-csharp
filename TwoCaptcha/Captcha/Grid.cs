using System;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Grid : Captcha
    {
        public Grid() : base()
        {
        }

        public Grid(string filePath) : this(new FileInfo(filePath))
        {
        }

        public Grid(FileInfo file) : this()
        {
            SetFile(file);
        }

        public void SetFile(String filePath)
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

        public void SetRows(int rows)
        {
            parameters["recaptcharows"] = Convert.ToString(rows);
        }

        public void SetCols(int cols)
        {
            parameters["recaptchacols"] = Convert.ToString(cols);
        }

        public void SetPreviousId(int previousId)
        {
            parameters["previousID"] = Convert.ToString(previousId);
        }

        public void SetCanSkip(bool canSkip)
        {
            parameters["can_no_answer"] = canSkip ? "1" : "0";
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
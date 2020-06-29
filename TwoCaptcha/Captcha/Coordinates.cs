using System.IO;

namespace TwoCaptcha.Captcha
{
    public class Coordinates : Captcha
    {
        public Coordinates() : base()
        {
            parameters["coordinatescaptcha"] = "1";
        }

        public Coordinates(string filePath) : this(new FileInfo(filePath))
        {
        }

        public Coordinates(FileInfo file) : this()
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

        public void SetBase64(string base64)
        {
            parameters["body"] = base64;
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
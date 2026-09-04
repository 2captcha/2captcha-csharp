using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TwoCaptcha.Captcha
{
    public class DragDrop : Captcha
    {
        public DragDrop() : base()
        {
            parameters["method"] = "drag_drop";
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

        public void SetImages(List<string> images)
        {
            parameters["images"] = JsonConvert.SerializeObject(images);
        }

        public void SetLang(string lang)
        {
            parameters["lang"] = lang;
        }

        public void SetHintText(string hintText)
        {
            parameters["textinstructions"] = hintText;
        }

        public void SetHeaderAcao(int headerAcao)
        {
            parameters["header_acao"] = headerAcao.ToString();
        }

        public void SetLanguage(int language)
        {
            parameters["language"] = language;
        }
    }
}

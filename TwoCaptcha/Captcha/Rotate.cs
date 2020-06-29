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

        public Rotate(string filePath) : this(new FileInfo(filePath))
        {
        }

        public Rotate(FileInfo file) : this()
        {
            SetFile(file);
        }

        public Rotate(List<FileInfo> files) : this()
        {
            SetFiles(files);
        }

        public void SetFile(String filePath)
        {
            SetFile(new FileInfo(filePath));
        }

        public void SetFile(FileInfo file)
        {
            files["file_1"] = file;
        }

        public void SetFiles(List<FileInfo> files)
        {
            int n = 1;

            foreach (FileInfo file in files)
            {
                this.files["file_" + n++] = file;
            }
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
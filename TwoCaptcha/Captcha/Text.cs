namespace TwoCaptcha.Captcha
{
    public class Text : Captcha
    {
        public Text() : base()
        {
            parameters["method"] = "post";
        }

        public Text(string text) : this()
        {
            SetText(text);
        }

        public void SetText(string text)
        {
            parameters["textcaptcha"] = text;
        }

        public void SetLang(string lang)
        {
            parameters["lang"] = lang;
        }
    }
}
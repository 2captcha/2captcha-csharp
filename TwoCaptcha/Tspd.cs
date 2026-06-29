namespace TwoCaptcha.Captcha
{
    public class Tspd : Captcha
    {
        public Tspd() : base()
        {
            parameters["method"] = "tspd";
        }

         public void SetTspdCookie(string tspdCookie)
        {
            parameters["tspd_cookie"] = tspdCookie;
        }

        public void SetHtmlPageBase64(string htmlPageBase64)
        {
            parameters["html_page_base64"] = htmlPageBase64;
        }
    }
}
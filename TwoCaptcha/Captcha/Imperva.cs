namespace TwoCaptcha.Captcha
{
    public class Imperva : Captcha
    {
        public Imperva() : base()
        {
            parameters["method"] = "incapsula";
        }

        public void SetIncapsulaScriptUrl(string incapsulaScriptUrl)
        {
            parameters["incapsula_script_url"] = incapsulaScriptUrl;
        }

        public void SetIncapsulaCookies(string incapsulaCookies)
        {
            parameters["incapsula_cookies"] = incapsulaCookies;
        }

        public void SetReese84UrlEndpoint(string reese84UrlEndpoint)
        {
            parameters["reese84_url_endpoint"] = reese84UrlEndpoint;
        }
    }
}

using System;

namespace TwoCaptcha.Captcha
{
    public class Hunt : Captcha
    {
        public Hunt() : base()
        {
            parameters["method"] = "hunt";
        }
        public void SetApiGetLib(string apiGetLib)
        {
            parameters["api_get_lib"] = apiGetLib;
        }

        public void SetData(string data)
        {
            parameters["data"] = data;
        }
    }
}

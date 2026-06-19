using System;

namespace TwoCaptcha.Captcha
{
    public class Yidun : Captcha
    {
        public Yidun() : base()
        {
            parameters["method"] = "yidun";
        }
        public void SetYidunGetLib(string yidunGetLib)
        {
            parameters["yidun_get_lib"] = yidunGetLib;
        }
        public void SetYidunApiServerSubdomain(string yidunApiServerSubdomain)
        {
            parameters["yidun_api_server_subdomain"] = yidunApiServerSubdomain;
        }
        public void SetChallenge(string challenge)
        {
            parameters["challenge"] = challenge;
        }
        public void SetHcg(string hcg)
        {
            parameters["hcg"] = hcg;
        }
        public void SetHct(int hct)
        {
            parameters["hct"] = Convert.ToString(hct);
        }
    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class VkImage : Captcha
    {
        public VkImage() : base()
        {
            parameters["method"] = "vkimage";
        }

        public void SetSteps(String steps)
        {
            parameters["steps"] =  steps;
        }
        
        public void SetBase64(String base64)
        {
            parameters["body"] = base64;
        }
        
        public void SetRedirectUri(String redirect_uri)
        {
            parameters["redirect_uri"] = redirect_uri;
        }

        public void SetuserAgent(String userAgent)
        {
            parameters["userAgent"] = userAgent;
        }
    }
}







using System;
using System.Collections.Generic;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public class GenericCaptcha
    {
        public string Id { get; set; }
        public string Code { get; set; }

        public Dictionary<string, string> parameters;
        public Dictionary<string, FileInfo> files;

        public GenericCaptcha()
        {
            parameters = new Dictionary<string, string>();
            files = new Dictionary<string, FileInfo>();
        }
        
        public void SetProxy(string type, string uri)
        {
            parameters["proxy"] = uri;
            parameters["proxytype"] = type;
        }

        public void SetSoftId(int softId)
        {
            parameters["soft_id"] = Convert.ToString(softId);
        }

        public void SetCallback(String callback)
        {
            parameters["pingback"] = callback;
        }

        public Dictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>(this.parameters);

            if (!parameters.ContainsKey("method"))
            {
                if (parameters.ContainsKey("body"))
                {
                    parameters["method"] = "base64";
                }
                else
                {
                    parameters["method"] = "post";
                }
            }

            return parameters;
        }

        public Dictionary<string, FileInfo> GetFiles()
        {
            return new Dictionary<string, FileInfo>(files);
        }

        public void SetUserAgent(string userAgent)
        {
            parameters["userAgent"] = userAgent;
        }
      
        public void SetSiteKey(String siteKey)
        {
            parameters["sitekey"] = siteKey;
        }

        public void SetPageUrl(String pageUrl)
        {
            parameters["pageurl"] = pageUrl;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace TwoCaptcha.Captcha
{
    public abstract class Captcha
    {
        public string Id { get; set; }
        public string Code { get; set; }

        protected Dictionary<string, string> parameters;
        protected Dictionary<string, FileInfo> files;

        public Captcha()
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
    }
}
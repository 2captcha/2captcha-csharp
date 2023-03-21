package com.twocaptcha.captcha;

public class AmazonWaf extends Captcha {

    public AmazonWaf() {
        super();
        params.put("method", "amazon_waf");
    }

    public void setSiteKey(String siteKey) {
        params.put("sitekey", siteKey);
    }

    public void setUrl(String url) {
        params.put("pageurl", url);
    }

    public void setIV(String iv) {
        params.put("iv", iv);
    }
    
    public void setContext(String context) {
        params.put("context", context);
    }
}

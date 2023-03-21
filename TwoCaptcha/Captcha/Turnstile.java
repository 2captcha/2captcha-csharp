package com.twocaptcha.captcha;

public class Turnstile extends Captcha {

    public Turnstile() {
        super();
        params.put("method", "turnstile");
    }

    public void setSiteKey(String siteKey) {
        params.put("sitekey", siteKey);
    }

    public void setUrl(String url) {
        params.put("pageurl", url);
    }

}

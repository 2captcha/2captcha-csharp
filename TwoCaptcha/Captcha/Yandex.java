package com.twocaptcha.captcha;

public class Yandex extends Captcha {

    public Yandex() {
        super();
        params.put("method", "yandex");
    }

    public void setSiteKey(String siteKey) {
        params.put("sitekey", siteKey);
    }

    public void setUrl(String url) {
        params.put("pageurl", url);
    }

}

package com.twocaptcha.captcha;

public class Audio extends Captcha {

    public Audio() {
        super();
        params.put("method", "solveaudio");
    }

    public void setBase64(String base64) {
        params.put("body", base64);
    }
    
    public void setLang(String lang) {
        params.put("lang", lang);
    }

}

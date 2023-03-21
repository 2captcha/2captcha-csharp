package com.twocaptcha.captcha;

public class GeeTestV4 extends Captcha {

    public GeeTestV4() {
        super();
        params.put("method", "geetest_v4");
    }

    public void setChallenge(String challenge) {
        params.put("challenge", challenge);
    }

    public void setUrl(String url) {
        params.put("pageurl", url);
    }

    public void setApiServer(String apiServer) {
        params.put("api_server", apiServer);
    }

    public void setCaptchaId(String captchaId) {
        params.put("captcha_id", captchaId);
    }    

}

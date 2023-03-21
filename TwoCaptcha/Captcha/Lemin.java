package com.twocaptcha.captcha;

public class Lemin extends Captcha {

    public Lemin() {
        super();
        params.put("method", "lemin");
    }

    public void setApiServer(String apiServer) {
        params.put("api_server", apiServer);
    }

    public void setСaptchaId(String captchaId) {
        params.put("captcha_id", captchaId);
    }    

    public void setUrl(String url) {
        params.put("pageurl", url);
    }

}

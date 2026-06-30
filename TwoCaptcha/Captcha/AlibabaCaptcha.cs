namespace TwoCaptcha.Captcha
{
    public class AlibabaCaptcha : Captcha
    {
        public AlibabaCaptcha() : base()
        {
            parameters["method"] = "alibaba";
        }

        public void SetSceneId(string sceneId)
        {
            parameters["scene_id"] = sceneId;
        }

        public void SetPrefix(string prefix)
        {
            parameters["prefix"] = prefix;
        }

        public void SetUserId(string userId)
        {
            parameters["user_id"] = userId;
        }

        public void SetUserUserId(string userUserId)
        {
            parameters["user_user_id"] = userUserId;
        }

        public void SetVerifyType(string verifyType)
        {
            parameters["verify_type"] = verifyType;
        }

        public void SetRegion(string region)
        {
            parameters["region"] = region;
        }

        public void SetUserCertifyId(string userCertifyId)
        {
            parameters["user_certify_id"] = userCertifyId;
        }

        public void SetApiGetLib(string apiGetLib)
        {
            parameters["api_get_lib"] = apiGetLib;
        }
    }
}

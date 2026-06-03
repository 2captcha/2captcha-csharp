namespace TwoCaptcha.Captcha
{
    public class BinanceCaptcha : Captcha
    {
        public BinanceCaptcha() : base()
        {
            parameters["method"] = "binance";
        }

        public void SetValidateId(string validateId)
        {
            parameters["validate_id"] = validateId;
        }
    }
}
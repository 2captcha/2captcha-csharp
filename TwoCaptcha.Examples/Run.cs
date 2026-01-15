using System;
using System.Runtime.ConstrainedExecution;
using TwoCaptcha.Examples;

public class Run
{
    public static void Main(string[] args)
    {
        string classToRun = args[0];
        string apiKey = args[1];

        switch (classToRun)
        {
            case "TextExample":
                TextExample textExample = new TextExample(apiKey);
                break;

            case "TextOptionsExample":
                TextOptionsExample TextOptionsExample = new TextOptionsExample(apiKey);
                break;

            case "MTCaptchaExample":
                MTCaptchaExample mtCaptchaExample = new MTCaptchaExample(apiKey);
                break;

            case "CutcaptchaExample":
                CutcaptchaExample cutcaptchaExample = new CutcaptchaExample(apiKey);
                break;

            case "CyberSiARAExample":
                CyberSiARAExample cyberSiARAExample = new CyberSiARAExample(apiKey);
                break;

            case "DataDomeExample":
                DataDomeExample dataDomeExample = new DataDomeExample(apiKey);
                break;

            case "AtbCAPTCHAExample":
                AtbCAPTCHAExample atbCAPTCHAExample = new AtbCAPTCHAExample(apiKey);
                break;

            case "TencentExample":
                TencentExample tencentExample = new TencentExample(apiKey);
                break; 

            case "AmazonWafExample":
                AmazonWafExample amazonWafExample = new AmazonWafExample(apiKey);
                break; 

            case "AmazonWafOptionsExample":
                AmazonWafOptionsExample amazonWafOptionsExample = new AmazonWafOptionsExample(apiKey);
                break;

            case "AudioCaptchaExample":
                AudioCaptchaExample AudioCaptchaExample = new AudioCaptchaExample(apiKey);
                break;

            case "AudioCaptchaOptionsExample":
                AudioCaptchaOptionsExample AudioCaptchaOptionsExample = new AudioCaptchaOptionsExample(apiKey);
                break;

            case "CanvasExample":
                CanvasExample CanvasExample = new CanvasExample(apiKey);
                break;

            case "CanvasBase64Example":
                CanvasBase64Example CanvasBase64Example = new CanvasBase64Example(apiKey);
                break;

            case "CanvasOptionsExample":
                CanvasOptionsExample CanvasOptionsExample = new CanvasOptionsExample(apiKey);
                break;

            case "CapyExample":
                CapyExample CapyExample = new CapyExample(apiKey);
                break;

            case "CapyOptionsExample":
                CapyOptionsExample CapyOptionsExample = new CapyOptionsExample(apiKey);
                break;

            case "CoordinatesExample":
                CoordinatesExample CoordinatesExample = new CoordinatesExample(apiKey);
                break;
                
            case "CoordinatesBase64Example":
                CoordinatesBase64Example CoordinatesBase64Example = new CoordinatesBase64Example(apiKey);
                break;

            case "CoordinatesOptionsExample":
                CoordinatesOptionsExample CoordinatesOptionsExample = new CoordinatesOptionsExample(apiKey);
                break;

            case "FriendlyCaptchaExample":
                FriendlyCaptchaExample FriendlyCaptchaExample = new FriendlyCaptchaExample(apiKey);
                break;

            case "FunCaptchaExample":
                FunCaptchaExample FunCaptchaExample = new FunCaptchaExample(apiKey);
                break;

            case "FunCaptchaOptionsExample":
                FunCaptchaOptionsExample FunCaptchaOptionsExample = new FunCaptchaOptionsExample(apiKey);
                break;

            case "GeeTestExample":
                GeeTestExample GeeTestExample = new GeeTestExample(apiKey);
                break;

            case "GeeTestOptionsExample":
                GeeTestOptionsExample GeeTestOptionsExample = new GeeTestOptionsExample(apiKey);
                break;

            case "GeeTestV4Example":
                GeeTestV4Example GeeTestV4Example = new GeeTestV4Example(apiKey);
                break;

            case "GeeTestV4OptionsExample":
                GeeTestV4OptionsExample GeeTestV4OptionsExample = new GeeTestV4OptionsExample(apiKey);
                break;

            case "GridExample":
                GridExample GridExample = new GridExample(apiKey);
                break;

            case "GridBase64Example":
                GridBase64Example GridBase64Example = new GridBase64Example(apiKey);
                break;

            case "GridOptionsExample":
                GridOptionsExample GridOptionsExample = new GridOptionsExample(apiKey);
                break;

            case "KeyCaptchaExample":
                KeyCaptchaExample KeyCaptchaExample = new KeyCaptchaExample(apiKey);
                break;

            case "KeyCaptchaOptionsExample":
                KeyCaptchaOptionsExample KeyCaptchaOptionsExample = new KeyCaptchaOptionsExample(apiKey);
                break;

            case "LeminExample":
                LeminExample LeminExample = new LeminExample(apiKey);
                break;

            case "LeminOptionsExample":
                LeminOptionsExample LeminOptionsExample = new LeminOptionsExample(apiKey);
                break;

            case "NormalExample":
                NormalExample NormalExample = new NormalExample(apiKey);
                break;

            case "NormalBase64Example":
                NormalBase64Example NormalBase64Example = new NormalBase64Example(apiKey);
                break;

            case "NormalOptionsExample":
                NormalOptionsExample NormalOptionsExample = new NormalOptionsExample(apiKey);
                break;

            case "ReCaptchaV2Example":
                ReCaptchaV2Example ReCaptchaV2Example = new ReCaptchaV2Example(apiKey);
                break;

            case "ReCaptchaV2OptionsExample":
                ReCaptchaV2OptionsExample ReCaptchaV2OptionsExample = new ReCaptchaV2OptionsExample(apiKey);
                break;

            case "ReCaptchaV3Example":
                ReCaptchaV3Example ReCaptchaV3Example = new ReCaptchaV3Example(apiKey);
                break;

            case "ReCaptchaV3OptionsExample":
                ReCaptchaV3OptionsExample ReCaptchaV3OptionsExample = new ReCaptchaV3OptionsExample(apiKey);
                break;

            case "RotateExample":
                RotateExample RotateExample = new RotateExample(apiKey);
                break;

            case "RotateOptionsExample":
                RotateOptionsExample RotateOptionsExample = new RotateOptionsExample(apiKey);
                break;

            case "TurnstileExample":
                TurnstileExample TurnstileExample = new TurnstileExample(apiKey);
                break;

            case "TurnstileOptionsExample":
                TurnstileOptionsExample TurnstileOptionsExample = new TurnstileOptionsExample(apiKey);
                break;

            case "YandexExample":
                YandexExample YandexExample = new YandexExample(apiKey);
                break;

            case "YandexOptionsExample":
                YandexOptionsExample YandexOptionsExample = new YandexOptionsExample(apiKey);
                break;

            case "ProsopoExample":
                ProsopoExample ProsopoExample = new ProsopoExample(apiKey);
                break;

            case "CaptchafoxExample":
                CaptchafoxExample CaptchafoxExample = new CaptchafoxExample(apiKey);
                break;

            case "TemuExample":
                TemuExample TemuExample = new TemuExample(apiKey);
            case "VkImageExample":
                VkImageExample VkImageExample = new VkImageExample(apiKey);
                break;

            case "VkCaptchaExample":
                VkCaptchaExample VkCaptchaExample = new VkCaptchaExample(apiKey);
                break;
        }
    }
}

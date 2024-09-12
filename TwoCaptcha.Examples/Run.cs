﻿using System;
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
                
        }
    }
}
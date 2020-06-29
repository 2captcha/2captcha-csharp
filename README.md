# C# Module for 2Captcha API
The easiest way to quickly integrate [2Captcha] into your code to automate solving of any types of captcha.

- [Installation](#installation)
- [Configuration](#configuration)
- [Basic example](#basic-example)
- [Supported captcha types](#supported-captcha-types)
  - [Normal Captcha](#normal-captcha)
  - [Text](#text-captcha)
  - [ReCaptcha v2](#recaptcha-v2)
  - [ReCaptcha v3](#recaptcha-v3)
  - [FunCaptcha](#funcaptcha)
  - [GeeTest](#geetest)
  - [hCaptcha](#hcaptcha)
  - [KeyCaptcha](#keycaptcha)
  - [Capy](#capy)
  - [Grid (ReCaptcha V2 Old Method)](#grid)
  - [Canvas](#canvas)
  - [ClickCaptcha](#clickcaptcha)
  - [Rotate](#rotate)
- [Other methods](#other-methods)
  - [send / getResult](#send--getresult)
  - [balance](#balance)
  - [report](#report)
- [Error handling](#error-handling)


## Installation
Maven repo: TODO

## Configuration
`TwoCaptcha` instance can be created like this:
```csharp
TwoCaptcha solver = new TwoCaptcha('YOUR_API_KEY');
```
Also there are few options that can be configured:
```csharp
solver.SoftId = 123;
solver.Callback = "https://your.site/result-receiver";
solver.DefaultTimeout = 120;
solver.RecaptchaTimeout = 600;
solver.PollingInterval = 10;
```

## Basic example
Example below shows how to solve simple captcha image. Check out `TwoCaptcha.Examples` directory to find more examples with all available options and captchas.
```csharp
Normal captcha = new Normal();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetMinLen(4);
captcha.SetMaxLen(20);
captcha.SetCaseSensitive(true);
captcha.SetLang("en");

try
{
    await solver.Solve(captcha);
    Console.WriteLine("Captcha solved: " + captcha.Code);
}
catch (Exception e)
{
    Console.WriteLine("Error occurred: " + e.Message);
}
```

## Supported captcha types

### Normal Captcha
```csharp
Normal captcha = new Normal();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetNumeric(4);
captcha.SetMinLen(4);
captcha.SetMaxLen(20);
captcha.SetPhrase(true);
captcha.SetCaseSensitive(true);
captcha.SetCalc(false);
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Type red symbols only");
```

### Text Captcha
```csharp
Text captcha = new Text();
captcha.SetText("If tomorrow is Saturday, what day is today?");
captcha.SetLang("en");
```

### ReCaptcha v2
```csharp
ReCaptcha captcha = new ReCaptcha();
captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
captcha.SetUrl("https://mysite.com/page/with/recaptcha");
captcha.SetInvisible(true);
captcha.SetAction("verify");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```
### ReCaptcha v3
```csharp
ReCaptcha captcha = new ReCaptcha();
captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
captcha.SetUrl("https://mysite.com/page/with/recaptcha");
captcha.SetVersion("v3");
captcha.SetAction("verify");
captcha.SetScore(0.3);
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### FunCaptcha
```csharp
FunCaptcha captcha = new FunCaptcha();
captcha.SetSiteKey("69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC");
captcha.SetUrl("https://mysite.com/page/with/funcaptcha");
captcha.SetSUrl("https://client-api.arkoselabs.com");
captcha.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36");
captcha.SetData("anyKey", "anyValue");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### GeeTest
```csharp
GeeTest captcha = new GeeTest();
captcha.SetGt("f2ae6cadcf7886856696502e1d55e00c");
captcha.SetApiServer("api-na.geetest.com");
captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
captcha.SetUrl("https://mysite.com/captcha.html");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### hCaptcha
```csharp
HCaptcha captcha = new HCaptcha();
captcha.SetSiteKey("10000000-ffff-ffff-ffff-000000000001");
captcha.SetUrl("https://www.site.com/page/");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### KeyCaptcha
```csharp
KeyCaptcha captcha = new KeyCaptcha();
captcha.SetUserId(10);
captcha.SetSessionId("493e52c37c10c2bcdf4a00cbc9ccd1e8");
captcha.SetWebServerSign("9006dc725760858e4c0715b835472f22");
captcha.SetWebServerSign2("2ca3abe86d90c6142d5571db98af6714");
captcha.SetUrl("https://www.keycaptcha.ru/demo-magnetic/");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### Capy
```csharp
Capy captcha = new Capy();
captcha.SetSiteKey("PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v");
captcha.SetUrl("https://www.mysite.com/captcha/");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### Grid
```csharp
Grid captcha = new Grid();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetRows(3);
captcha.SetCols(3);
captcha.SetPreviousId(0);
captcha.SetCanSkip(false);
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Select all images with an Orange");
```

### Canvas
```csharp
Canvas captcha = new Canvas();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetPreviousId(0);
captcha.SetCanSkip(false);
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Draw around apple");
```

### ClickCaptcha
```csharp
Coordinates captcha = new Coordinates();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Select all images with an Orange");
```

### Rotate
```csharp
Rotate captcha = new Rotate();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetAngle(40);
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Put the images in the correct way up");
```

## Other methods

### send / getResult
```csharp
string captchaId = await solver.Send(captcha);

Task.sleep(20 * 1000);

string code = await solver.GetResult(captchaId);
```
### balance
```csharp
double balance = await solver.Balance();
```
### report
```csharp
await solver.Report(captcha.Id, true); // captcha solved correctly
await solver.Report(captcha.Id, false); // captcha solved incorrectly
```

## Error handling
```csharp
try
{
    await solver.Solve(captcha);
}
catch (ValidationException e)
{
    // invalid parameters passed
}
catch (NetworkException e)
{
    // network error occurred
}
catch (ApiException e)
{
    // api respond with error
}
catch (TimeoutException e)
{
    // captcha is not solved so far
}
```
[2Captcha]: https://2captcha.com/

# C# Module for 2Captcha API
The easiest way to quickly integrate [2Captcha] into your code to automate solving of any types of captcha.

- [Installation](#installation)
- [Configuration](#configuration)
- [Solve captcha](#solve-captcha)
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
  - [Audio](#audio)
  - [Yandex](#yandex)
  - [Lemin](#lemin)
  - [Turnstile](#turnstile)
- [Other methods](#other-methods)
  - [send / getResult](#send--getresult)
  - [balance](#balance)
  - [report](#report)
- [Error handling](#error-handling)

## Installation
Install nuget package from [nuget]

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

### TwoCaptcha instance options

|Option|Default value|Description|
|---|---|---|
|softId|-|your software ID obtained after publishing in [2captcha sofware catalog]|
|callback|-|URL of your web-sever that receives the captcha recognition result. The URl should be first registered in [pingback settings] of your account|
|defaultTimeout|120|Polling timeout in seconds for all captcha types except ReCaptcha. Defines how long the module tries to get the answer from `res.php` API endpoint|
|recaptchaTimeout|600|Polling timeout for ReCaptcha in seconds. Defines how long the module tries to get the answer from `res.php` API endpoint|
|pollingInterval|10|Interval in seconds between requests to `res.php` API endpoint, setting values less than 5 seconds is not recommended|

>  **IMPORTANT:** once `Callback` is defined for `TwoCaptcha` instance, all methods return only the captcha ID and DO NOT poll the API to get the result. The result will be sent to the callback URL.
To get the answer manually use [getResult method](#send--getresult)

## Solve captcha
When you submit any image-based captcha use can provide additional options to help 2captcha workers to solve it properly.

### Captcha options
|Option|Default Value|Description|
|---|---|---|
|numeric|0|Defines if captcha contains numeric or other symbols [see more info in the API docs][post options]|
|minLength|0|minimal answer lenght|
|maxLength|0|maximum answer length|
|phrase|0|defines if the answer contains multiple words or not|
|caseSensitive|0|defines if the answer is case sensitive|
|calc|0|defines captcha requires calculation|
|lang|-|defines the captcha language, see the [list of supported languages] |
|hintImg|-|an image with hint shown to workers with the captcha|
|hintText|-|hint or task text shown to workers with the captcha|

Below you can find basic examples for every captcha type. Check out [examples directory] to find more examples with all available options.

### Basic example
Example below shows a basic solver call example with error handling.

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

### Normal Captcha
To bypass a normal captcha (distorted text on image) use the following method. This method also can be used to recognize any text on the image.

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
This method can be used to bypass a captcha that requires to answer a question provided in clear text.

```csharp
Text captcha = new Text();
captcha.SetText("If tomorrow is Saturday, what day is today?");
captcha.SetLang("en");
```

### ReCaptcha v2
Use this method to solve ReCaptcha V2 and obtain a token to bypass the protection.

```csharp
ReCaptcha captcha = new ReCaptcha();
captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
captcha.SetUrl("https://mysite.com/page/with/recaptcha");
captcha.SetInvisible(true);
captcha.SetEnterprise(false);
captcha.SetAction("verify");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```
### ReCaptcha v3
This method provides ReCaptcha V3 solver and returns a token.

```csharp
ReCaptcha captcha = new ReCaptcha();
captcha.SetSiteKey("6Le-wvkSVVABCPBMRTvw0Q4Muexq1bi0DJwx_mJ-");
captcha.SetUrl("https://mysite.com/page/with/recaptcha");
captcha.SetVersion("v3");
captcha.SetEnterprise(false);
captcha.SetDomain("google.com");
captcha.SetAction("verify");
captcha.SetScore(0.3);
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### FunCaptcha
FunCaptcha (Arkoselabs) solving method. Returns a token.

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
Method to solve GeeTest puzzle captcha. Returns a set of tokens as JSON.

```csharp
GeeTest captcha = new GeeTest();
captcha.SetGt("f2ae6cadcf7886856696502e1d55e00c");
captcha.SetApiServer("api-na.geetest.com");
captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
captcha.SetUrl("https://mysite.com/captcha.html");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### hCaptcha
Use this method to solve hCaptcha challenge. Returns a token to bypass captcha.

```csharp
HCaptcha captcha = new HCaptcha();
captcha.SetSiteKey("10000000-ffff-ffff-ffff-000000000001");
captcha.SetUrl("https://www.site.com/page/");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### KeyCaptcha
Token-based method to solve KeyCaptcha.

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
Token-based method to bypass Capy puzzle captcha.

```csharp
Capy captcha = new Capy();
captcha.SetSiteKey("PUZZLE_Abc1dEFghIJKLM2no34P56q7rStu8v");
captcha.SetUrl("https://www.mysite.com/captcha/");
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
```

### Grid
Grid method is originally called Old ReCaptcha V2 method. The method can be used to bypass any type of captcha where you can apply a grid on image and need to click specific grid boxes. Returns numbers of boxes.

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
Canvas method can be used when you need to draw a line around an object on image. Returns a set of points' coordinates to draw a polygon.

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
ClickCaptcha method returns coordinates of points on captcha image. Can be used if you need to click on particular points on the image.

```csharp
Coordinates captcha = new Coordinates();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Select all images with an Orange");
```

### Rotate
This method can be used to solve a captcha that asks to rotate an object. Mostly used to bypass FunCaptcha. Returns the rotation angle.

```csharp
Rotate captcha = new Rotate();
captcha.SetFile("path/to/captcha.jpg");
captcha.SetAngle(40);
captcha.SetLang("en");
captcha.SetHintImg(new FileInfo("path/to/hint.jpg"));
captcha.SetHintText("Put the images in the correct way up");
```

### Audio
This method can be used to solve a audio captcha

```csharp
AudioCaptcha captcha = new AudioCaptcha();
byte[] bytes = File.ReadAllBytes("../../resources/audio-en.mp3");
string base64EncodedImage = Convert.ToBase64String(bytes);
captcha.SetBase64(base64EncodedImage);
```

### Yandex
Use this method to solve Yandex and obtain a token to bypass the protection.

```csharp
Yandex captcha = new Yandex();
captcha.SetSiteKey("Y5Lh0tiycconMJGsFd3EbbuNKSp1yaZESUOIHfeV");
captcha.SetUrl("https://rutube.ru");
```

### Lemin
Use this method to solve Lemin and obtain a token to bypass the protection.

```csharp
Lemin captcha = new Lemin();
captcha.SetCaptchaId("CROPPED_d3d4d56_73ca4008925b4f83a8bed59c2dd0df6d");
captcha.SetApiServer("api.leminnow.com");
captcha.SetUrl("http://sat2.aksigorta.com.tr");
```

### Turnstile
```csharp
Turnstile captcha = new Turnstile();
captcha.SetSiteKey("0x4AAAAAAAChNiVJM_WtShFf");
captcha.SetUrl("https://ace.fusionist.io");
```


## Other methods

### send / getResult
These methods can be used for manual captcha submission and answer polling.

```csharp
string captchaId = await solver.Send(captcha);

Task.sleep(20 * 1000);

string code = await solver.GetResult(captchaId);
```
### balance
Use this method to get your account's balance

```csharp
double balance = await solver.Balance();
```
### report
Use this method to report good or bad captcha answer.

```csharp
await solver.Report(captcha.Id, true); // captcha solved correctly
await solver.Report(captcha.Id, false); // captcha solved incorrectly
```

## Error handling
If case of an error captcha solver throws an exception. It's important to properly handle these cases. We recommend to use `try catch` to handle exceptions.


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
[nuget]: https://www.nuget.org/packages/2captcha-csharp/
[2Captcha]: https://2captcha.com/
[2captcha sofware catalog]: https://2captcha.com/software
[pingback settings]: https://2captcha.com/setting/pingback
[post options]: https://2captcha.com/2captcha-api#normal_post
[list of supported languages]: https://2captcha.com/2captcha-api#language
[examples directory]: /TwoCaptcha.Examples

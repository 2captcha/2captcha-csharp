<a href="https://github.com/2captcha/2captcha-python"><img src="https://github.com/user-attachments/assets/37e1d860-033b-4cf3-a158-468fc6b4debc" width="82" height="30"></a>
<a href="https://github.com/2captcha/2captcha-javascript"><img src="https://github.com/user-attachments/assets/e81e9714-7bd8-40f9-971c-b08bf9da6b97" width="36" height="30"></a>
<a href="https://github.com/2captcha/2captcha-go"><img src="https://github.com/user-attachments/assets/ab22182e-6cb2-41fa-91f4-d5e89c6d7c6f" width="63" height="30"></a>
<a href="https://github.com/2captcha/2captcha-ruby"><img src="https://github.com/user-attachments/assets/0270d56f-79b0-4c95-9b09-4de89579914b" width="75" height="30"></a>
<a href="https://github.com/2captcha/2captcha-cpp"><img src="https://github.com/user-attachments/assets/36de8512-acfd-44fb-bb1f-b7c793a3f926" width="45" height="30"></a>
<a href="https://github.com/2captcha/2captcha-php"><img src="https://github.com/user-attachments/assets/e8797843-3f61-4fa9-a155-ab0b21fb3858" width="52" height="30"></a>
<a href="https://github.com/2captcha/2captcha-java"><img src="https://github.com/user-attachments/assets/a3d923f6-4fec-4c07-ac50-e20da6370911" width="50" height="30"></a>
<a href="https://github.com/2captcha/2captcha-csharp"><img src="https://github.com/user-attachments/assets/4dff0a3e-0ed7-46bd-8c59-4b95451aa54d" width="38" height="30"></a>

# C# Module for 2Captcha API (captcha solver)
The easiest way to quickly integrate [2Captcha] into your code to automate solving of any types of captcha.
Examples of API requests for different captcha types are available on the [C# captcha solver](https://2captcha.com/lang/csharp) page.

- [C# Module for 2Captcha API (captcha solver)](#c-module-for-2captcha-api-captcha-solver)
  - [Installation](#installation)
  - [Configuration](#configuration)
    - [TwoCaptcha instance options](#twocaptcha-instance-options)
  - [Solve captcha](#solve-captcha)
    - [Captcha options](#captcha-options)
    - [Basic example](#basic-example)
    - [Normal Captcha](#normal-captcha)
    - [Text Captcha](#text-captcha)
    - [ReCaptcha v2](#recaptcha-v2)
    - [ReCaptcha v3](#recaptcha-v3)
    - [FunCaptcha](#funcaptcha)
    - [GeeTest](#geetest)
    - [GeeTestV4](#geetestv4)
    - [hCaptcha](#hcaptcha)
    - [KeyCaptcha](#keycaptcha)
    - [Capy](#capy)
    - [Grid](#grid)
    - [Canvas](#canvas)
    - [ClickCaptcha](#clickcaptcha)
    - [Rotate](#rotate)
    - [Audio](#audio)
    - [Yandex](#yandex)
    - [Lemin](#lemin)
    - [Turnstile](#turnstile)
    - [AmazonWaf](#amazonwaf)
    - [Friendly Captcha](#friendly-captcha)
    - [MT Captcha](#mt-captcha)
    - [Cutcaptcha](#cutcaptcha)
    - [CyberSiARA](#cyberSiARA)
    - [DataDome](#datadome)
  - [Other methods](#other-methods)
    - [send / getResult](#send--getresult)
    - [balance](#balance)
    - [report](#report)
  - [Proxies](#proxies)
  - [Error handling](#error-handling)
  - [Get in touch](#get-in-touch)
  - [Join the team 👪](#join-the-team-)
- [License](#license)
    - [Graphics and Trademarks](#graphics-and-trademarks)

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

| Option           | Default value | Description                                                                                                                                        |
| ---------------- | ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| softId           | -             | your software ID obtained after publishing in [2captcha sofware catalog]                                                                           |
| callback         | -             | URL of your web-sever that receives the captcha recognition result. The URl should be first registered in [pingback settings] of your account      |
| defaultTimeout   | 120           | Polling timeout in seconds for all captcha types except ReCaptcha. Defines how long the module tries to get the answer from `res.php` API endpoint |
| recaptchaTimeout | 600           | Polling timeout for ReCaptcha in seconds. Defines how long the module tries to get the answer from `res.php` API endpoint                          |
| pollingInterval  | 10            | Interval in seconds between requests to `res.php` API endpoint, setting values less than 5 seconds is not recommended                              |

>  **IMPORTANT:** once `Callback` is defined for `TwoCaptcha` instance, all methods return only the captcha ID and DO NOT poll the API to get the result. The result will be sent to the callback URL.
To get the answer manually use [getResult method](#send--getresult)

## Solve captcha
When you submit any image-based captcha use can provide additional options to help 2captcha workers to solve it properly.

### Captcha options
| Option        | Default Value | Description                                                                                        |
| ------------- | ------------- | -------------------------------------------------------------------------------------------------- |
| numeric       | 0             | Defines if captcha contains numeric or other symbols [see more info in the API docs][post options] |
| minLength     | 0             | minimal answer lenght                                                                              |
| maxLength     | 0             | maximum answer length                                                                              |
| phrase        | 0             | defines if the answer contains multiple words or not                                               |
| caseSensitive | 0             | defines if the answer is case sensitive                                                            |
| calc          | 0             | defines captcha requires calculation                                                               |
| lang          | -             | defines the captcha language, see the [list of supported languages]                                |
| hintImg       | -             | an image with hint shown to workers with the captcha                                               |
| hintText      | -             | hint or task text shown to workers with the captcha                                                |

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

### GeeTestV4
Method to solve GeeTestV4 puzzle captcha. Returns a set of tokens as JSON.

```csharp
GeeTestV4 captcha = new GeeTestV4();
captcha.SetCaptchaId("72bf15796d0b69c43867452fea615052");
captcha.SetChallenge("12345678abc90123d45678ef90123a456b");
captcha.SetUrl("https://mysite.com/captcha.html");
```

### hCaptcha
Use this method to solve hCaptcha challenge. Returns a token to bypass captcha.

```csharp
HCaptcha captcha = new HCaptcha();
captcha.SetSiteKey("10000000-ffff-ffff-ffff-000000000001");
captcha.SetUrl("https://www.site.com/page/");
captcha.SetData("foo");
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
Use this method to solve Turnstile and obtain a token to bypass the protection.

```csharp
Turnstile captcha = new Turnstile();
captcha.SetSiteKey("0x4AAAAAAAChNiVJM_WtShFf");
captcha.SetUrl("https://ace.fusionist.io");
captcha.SetData("foo");
captcha.SetPageData("bar");
captcha.SetAction("baz");
```

### AmazonWaf
Use this method to solve AmazonWaf and obtain a token to bypass the protection.

```csharp
AmazonWaf captcha = new AmazonWaf();
captcha.SetSiteKey("AQIDAHjcYu/GjX+QlghicBgQ/7bFaQZ+m5FKCMDnO+vTbNg96AF5H1K/siwSLK7RfstKtN5bAAAAfjB8BgkqhkiG9w0BBwagbzBtAgEAMGgGCSqGSIb3DQEHATAeBglg");
captcha.SetUrl("https://non-existent-example.execute-api.us-east-1.amazonaws.com");
captcha.SetContext("test_iv");
captcha.SetIV("test_context");
```

### Friendly Captcha
Use this method to solve Friendly Captcha. Returns a token to bypass the captcha.

```csharp
FriendlyCaptcha captcha = new FriendlyCaptcha();
captcha.SetSiteKey("2FZFEVS1FZCGQ9");
captcha.SetUrl("https://example.com");
```

### MT Captcha
Use this method to solve MT Captcha. Returns a token to bypass the captcha.

```csharp
MTCaptcha captcha = new MTCaptcha();
captcha.SetSiteKey("MTPublic-KzqLY1cKH");
captcha.SetPageUrl("https://2captcha.com/demo/mtcaptcha");
```

### Cutcaptcha
Use this method to solve Cutcaptcha. Returns a token to bypass the captcha.

```csharp
Cutcaptcha captcha = new Cutcaptcha();
captcha.SetMiseryKey("a1488b66da00bf332a1488993a5443c79047e752");
captcha.SetPageUrl("https://example.cc/foo/bar.html");
captcha.SetApiKey("SAb83IIB");
```

### CyberSiARA
Use this method to solve Cutcaptcha. Returns a token to bypass the captcha.

```csharp
CyberSiARA cyberSiARA = new CyberSiARA();
cyberSiARA.SetMasterUrlId("tpjOCKjjpdzv3d8Ub2E9COEWKt1vl1Mv");
cyberSiARA.SetPageUrl("https://demo.mycybersiara.com/");
cyberSiARA.SetUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");

```

### DataDome
Use this method to solve DataDome. Returns a token to bypass the captcha.

```csharp
DataDome dataDome = new DataDome();
dataDome.SetCapthaUrl("https://geo.captcha-delivery.com/captcha/?initialCid=AHrlqAAA...P~XFrBVptk&t=fe&referer=https%3A%2F%2Fhexample.com&s=45239&e=c538be..c510a00ea");
dataDome.SetPageUrl("https://example.com/");
dataDome.SetProxy("http", "username:password@1.2.3.4:5678");
dataDome.SetUserAgent("Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Mobile Safari/537.3");```


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
## Proxies

You can pass your proxy as an additional argument for methods: recaptcha, funcaptcha, geetest, geetest v4, hcaptcha, keycaptcha, capy puzzle, lemin, turnstile, amazon waf and etc. The proxy will be forwarded to the API to solve the captcha.

We have our own proxies that we can offer you. [Buy residential proxies](https://2captcha.com/proxy/residential-proxies) for avoid restrictions and blocks. [Quick start](https://2captcha.com/proxy?openAddTrafficModal=true).

```csharp
captcha.SetProxy("HTTPS", "login:password@IP_address:PORT");
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

## Get in touch

<a href="mailto:support@2captcha.com"><img src="https://github.com/user-attachments/assets/539df209-7c85-4fa5-84b4-fc22ab93fac7" width="80" height="30"></a>
<a href="https://2captcha.com/support/tickets/new"><img src="https://github.com/user-attachments/assets/be044db5-2e67-46c6-8c81-04b78bd99650" width="81" height="30"></a>

## Join the team 👪

There are many ways to contribute, of which development is only one! Find your next job. Open positions: AI experts, scrapers, developers, technical support, and much more! 😍

<a href="mailto:job@2captcha.com"><img src="https://github.com/user-attachments/assets/36d23ef5-7866-4841-8e17-261cc8a4e033" width="80" height="30"></a>

# License

The code in this repository is licensed under the MIT License. See the [LICENSE](./LICENSE) file for more details.

### Graphics and Trademarks

The graphics and trademarks included in this repository are not covered by the MIT License. Please contact <a href="mailto:support@2captcha.com">support</a> for permissions regarding the use of these materials.


<!-- Shared links -->
[nuget]: https://www.nuget.org/packages/2captcha-csharp/
[2Captcha]: https://2captcha.com/
[2captcha sofware catalog]: https://2captcha.com/software
[Pingback settings]: https://2captcha.com/setting/pingback
[Post options]: https://2captcha.com/2captcha-api#normal_post
[list of supported languages]: https://2captcha.com/2captcha-api#language
[Examples directory]: /TwoCaptcha.Examples

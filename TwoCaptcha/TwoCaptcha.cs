using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TwoCaptcha.Captcha;
using TwoCaptcha.Exceptions;
using TimeoutException = TwoCaptcha.Exceptions.TimeoutException;

namespace TwoCaptcha
{
    public class TwoCaptcha
    {
        /**
         * API KEY
         */
        public string ApiKey { get; set; }

        /**
         * ID of software developer. Developers who integrated their software
         * with our service get reward: 10% of spendings of their software users.
         */
        public int SoftId { get; set; }

        /**
         * URL to which the result will be sent
         */
        public string Callback { get; set; }

        /**
         * How long should wait for captcha result (in seconds)
         */
        public int DefaultTimeout { get; set; } = 120;

        /**
         * How long should wait for recaptcha result (in seconds)
         */
        public int RecaptchaTimeout { get; set; } = 600;

        /**
         * How often do requests to `/res.php` should be made
         * in order to check if a result is ready (in seconds)
         */
        public int PollingInterval { get; set; } = 10;

        /**
         * Helps to understand if there is need of waiting
         * for result or not (because callback was used)
         */
        private bool lastCaptchaHasCallback;

        /**
         * Network client
         */
        private ApiClient apiClient;

        /**
         * TwoCaptcha constructor
         */
        public TwoCaptcha()
        {
            apiClient = new ApiClient();
        }

        /**
         * TwoCaptcha constructor
         *
         * @param apiKey
         */
        public TwoCaptcha(string apiKey) : this()
        {
            ApiKey = apiKey;
        }

        /**
         * @param apiClient
         */
        public void SetApiClient(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /**
         * Sends captcha to `/in.php` and waits for it's result.
         * This helper can be used instead of manual using of `send` and `getResult` functions.
         *
         * @param captcha
         * @throws Exception
         */
        public async Task Solve(Captcha.Captcha captcha)
        {
            var waitOptions = new Dictionary<string, int>();

            if (captcha.GetType() == typeof(ReCaptcha))
            {
                waitOptions["timeout"] = RecaptchaTimeout;
            }

            await Solve(captcha, waitOptions);
        }

        /**
         * Sends captcha to `/in.php` and waits for it's result.
         * This helper can be used instead of manual using of `send` and `getResult` functions.
         *
         * @param captcha
         * @param waitOptions
         * @throws Exception
         */
        public async Task Solve(Captcha.Captcha captcha, Dictionary<string, int> waitOptions)
        {
            captcha.Id = await Send(captcha);

            if (!lastCaptchaHasCallback)
            {
                await WaitForResult(captcha, waitOptions);
            }
        }

        /**
         * This helper waits for captcha result, and when result is ready, returns it
         *
         * @param captcha
         * @param waitOptions
         * @throws Exception
         */
        public async Task WaitForResult(Captcha.Captcha captcha, Dictionary<string, int> waitOptions)
        {
            long startedAt = CurrentTime();

            int timeout = waitOptions.TryGetValue("timeout", out timeout) ? timeout : DefaultTimeout;
            int pollingInterval = waitOptions.TryGetValue("pollingInterval", out pollingInterval)
                ? pollingInterval
                : PollingInterval;

            while (true)
            {
                long now = CurrentTime();

                if (now - startedAt < timeout)
                {
                    await Task.Delay(pollingInterval * 1000).ConfigureAwait(false);
                }
                else
                {
                    break;
                }

                try
                {
                    string result = await GetResult(captcha.Id);
                    if (result != null)
                    {
                        captcha.Code = result;
                        return;
                    }
                }
                catch (NetworkException)
                {
                    // ignore network errors
                }
            }

            throw new TimeoutException("Timeout " + timeout + " seconds reached");
        }

        private long CurrentTime()
        {
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        /**
         * Sends captcha to '/in.php', and returns its `id`
         *
         * @param captcha
         * @return
         * @throws Exception
         */
        public async Task<string> Send(Captcha.Captcha captcha)
        {
            var parameters = captcha.GetParameters();
            var files = captcha.GetFiles();

            SendAttachDefaultParameters(parameters);

            ValidateFiles(files);

            string response = await apiClient.In(parameters, files);

            if (!response.StartsWith("OK|"))
            {
                throw new ApiException("Cannot recognise api response (" + response + ")");
            }

            return response.Substring(3);
        }

        /**
         * Returns result of captcha if it was solved or `null`, if result is not ready
         *
         * @param id
         * @return
         * @throws Exception
         */
        public async Task<string> GetResult(String id)
        {
            var parameters = new Dictionary<string, string>();
            parameters["action"] = "get";
            parameters["id"] = id;

            string response = await Res(parameters);

            if (response.Equals("CAPCHA_NOT_READY"))
            {
                return null;
            }

            if (!response.StartsWith("OK|"))
            {
                throw new ApiException("Cannot recognise api response (" + response + ")");
            }

            return response.Substring(3);
        }

        /**
         * Gets account's balance
         *
         * @return
         * @throws Exception
         */
        public async Task<double> Balance()
        {
            string response = await Res("getbalance");
            return Convert.ToDouble(response);
        }

        /**
         * Reports if captcha was solved correctly (sends `reportbad` or `reportgood` to `/res.php`)
         *
         * @param id
         * @param correct
         * @throws Exception
         */
        public async Task Report(string id, bool correct)
        {
            var parameters = new Dictionary<string, string>();
            parameters["id"] = id;

            if (correct)
            {
                parameters["action"] = "reportgood";
            }
            else
            {
                parameters["action"] = "reportbad";
            }

            await Res(parameters);
        }

        /**
         * Makes request to `/res.php`
         *
         * @param action
         * @return
         * @throws Exception
         */
        private async Task<string> Res(string action)
        {
            var parameters = new Dictionary<string, string>();
            parameters["action"] = action;
            return await Res(parameters);
        }

        /**
         * Makes request to `/res.php`
         *
         * @param params
         * @return
         * @throws Exception
         */
        private async Task<string> Res(Dictionary<string, string> parameters)
        {
            parameters["key"] = ApiKey;
            return await apiClient.Res(parameters);
        }

        /**
         * Attaches default parameters to request
         *
         * @param params
         */
        private void SendAttachDefaultParameters(Dictionary<string, string> parameters)
        {
            parameters["key"] = ApiKey;

            if (Callback != null)
            {
                if (!parameters.ContainsKey("pingback"))
                {
                    parameters["pingback"] = Callback;
                }
                else if (parameters["pingback"].Length == 0)
                {
                    parameters.Remove("pingback");
                }
            }

            lastCaptchaHasCallback = parameters.ContainsKey("pingback");

            if (SoftId != 0 && !parameters.ContainsKey("soft_id"))
            {
                parameters["soft_id"] = Convert.ToString(SoftId);
            }
        }

        /**
         * Validates if files parameters are correct
         *
         * @param files
         * @throws ValidationException
         */
        private void ValidateFiles(Dictionary<string, FileInfo> files)
        {
            foreach (KeyValuePair<string, FileInfo> entry in files)
            {
                FileInfo file = entry.Value;

                if (!file.Exists)
                {
                    throw new ValidationException("File not found: " + file.FullName);
                }
            }
        }
    }
}
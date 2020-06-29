using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace TwoCaptcha.Tests
{
    public abstract class AbstractWrapperTestCase
    {
        protected async Task CheckIfCorrectParamsSendAndResultReturned(
            Captcha.Captcha captcha,
            Dictionary<string, string> parameters
        )
        {
            var files = new Dictionary<string, FileInfo>();
            await CheckIfCorrectParamsSendAndResultReturned(captcha, parameters, files);
        }

        protected async Task CheckIfCorrectParamsSendAndResultReturned(
            Captcha.Captcha captcha,
            Dictionary<string, string> parameters,
            Dictionary<string, FileInfo> files
        )
        {
            string apiKey = "API_KEY";
            string captchaId = "123";
            string code = "2763";

            parameters["key"] = apiKey;

            var resParameters = new Dictionary<string, string>();
            resParameters["action"] = "get";
            resParameters["id"] = captchaId;
            resParameters["key"] = apiKey;


            var apiClientMock = new Mock<ApiClient>();
            apiClientMock
                .Setup(ac => ac.In(It.IsAny<Dictionary<string, string>>(), It.IsAny<Dictionary<string, FileInfo>>()))
                .Returns(Task.FromResult("OK|" + captchaId));
            apiClientMock
                .Setup(ac => ac.Res(resParameters))
                .Returns(Task.FromResult("OK|" + code));

            TwoCaptcha solver = new TwoCaptcha(apiKey);
            solver.PollingInterval = 1;
            solver.SetApiClient(apiClientMock.Object);

            await solver.Solve(captcha);

            apiClientMock.Verify(ac => ac.In(
                It.Is<Dictionary<string, string>>(actual => ParametersAreSame(parameters, actual)),
                It.Is<Dictionary<string, FileInfo>>(actual => FilesAreSame(files, actual))
            ));

            Assert.AreEqual(captchaId, captcha.Id);
            Assert.AreEqual(code, captcha.Code);
        }

        private bool ParametersAreSame(Dictionary<string, string> expected, Dictionary<string, string> actual)
        {
            if (expected.Count != actual.Count) return false;

            foreach (KeyValuePair<string, string> entry in expected)
            {
                if (!actual.ContainsKey(entry.Key)) return false;

                if (!actual[entry.Key].Equals(entry.Value)) return false;
            }

            return true;
        }

        private bool FilesAreSame(Dictionary<string, FileInfo> expected, Dictionary<string, FileInfo> actual)
        {
            if (expected.Count != actual.Count) return false;

            foreach (KeyValuePair<string, FileInfo> entry in expected)
            {
                if (!actual.ContainsKey(entry.Key)) return false;

                if (!actual[entry.Key].FullName.Equals(entry.Value.FullName)) return false;
            }

            return true;
        }
    }
}
using Language.Tests;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Tests
{
    public class DetectLanguageTests : BaseTests
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6212")]
        public async Task DetectLanguage()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DetectLanguage");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                LanguageBatchResult result = await client.DetectLanguageAsync(
                    null,
                    new LanguageBatchInput(
                        new List<LanguageInput>()
                        {
                            new LanguageInput("en","id","I love my team mates")
                        }));

                Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
                Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);
                Assert.True(result.Documents[0].DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }
    }
}

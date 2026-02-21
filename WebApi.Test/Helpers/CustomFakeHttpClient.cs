using FakeItEasy;
using System.Text.Json;

namespace Test.Helpers
{
    public static class CustomFakeHttpClient
    {
        public static HttpClient FakeHttpClient<T>(T content)
        {
            var respnse = new HttpResponseMessage
            {   
                Content = new StringContent(JsonSerializer.Serialize(content))
            };
            var handler = A.Fake<FakeableHttpMessageHandler>();
            A.CallTo(() => handler.FakeSendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored)).Returns(respnse);
            return new HttpClient(handler);
        }
    }
}

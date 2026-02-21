
namespace Test.Helpers
{
    public abstract class FakeableHttpMessageHandler : HttpMessageHandler
    {
        public abstract Task<HttpResponseMessage> FakeSendAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken);

        protected sealed override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
            => this.FakeSendAsync(request, cancellationToken);
    }
}

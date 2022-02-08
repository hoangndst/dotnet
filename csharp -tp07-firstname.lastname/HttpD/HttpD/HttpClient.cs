using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpD
{
    public class HttpClientStream
    {
        private readonly HttpClient _httpClient;

        private HttpMethod _method;
        
        // TODO: getter for _httpClient named `httpClient`
        // TODO: getter for _method named `Method`
        public HttpClient httpClient => this._httpClient;

        public HttpMethod Methode => this._method;
        
        public HttpClientStream(HttpMethod method, string url = "http://127.0.0.1:8000")
        {
            // TODO: initialisation of _httpClient
            _method = method;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Clear();

        }
        
        public StreamReader SendMessage(string message = "")
        {
            // TODO: send a message and return the stream associated to the response
            HttpRequestMessage request = new HttpRequestMessage(_method, _httpClient.BaseAddress);
            request.Content = new StringContent(message);
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            return new StreamReader(response.Content.ReadAsStreamAsync().Result);
            // throw new NotImplementedException();
        }

        public string ResponseFromStream(StreamReader stream)
        {
            // TODO: Get string from a response stream
            string response = stream.ReadToEnd();
            stream.Close();
            return response;
        }
    }
}
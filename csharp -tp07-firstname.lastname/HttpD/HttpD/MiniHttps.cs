using System;

namespace HttpD
{
    public class MiniHttps
    {
        private byte[] _key;
        private HttpClientStream _client;
        
        public MiniHttps(string url, string key)
        {
            // TODO: Initialize attributes
            throw new NotImplementedException();
        }

        public byte[] EncryptFullMessage(string message)
        {
            // TODO: Encrypt string message to byte array

            throw new NotImplementedException();
        }
        
        public string DecryptFullCipher(byte[] cipher)
        {
            // TODO: Decrypt byte array to string message
            throw new NotImplementedException();
        }

        public string EncryptAndSend(string message)
        {
            // TODO: Send a string message encrypted and get the decrypted response
            throw new NotImplementedException();
        }
    }
}
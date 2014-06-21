using System;
using JsonFx.Serialization;
using JsonFx.Serialization.Providers;

namespace EasyHttp.Codecs
{
    public class DefaultDecoder : IDecoder
    {
        private readonly IDataReaderProvider _dataReaderProvider;

        public DefaultDecoder(IDataReaderProvider dataReaderProvider)
        {
            _dataReaderProvider = dataReaderProvider;
        }

        public T DecodeToStatic<T>(string input, string contentType)
        {
            var parsedText = VerifyNullOrEmpty(input);

            var deserializer = ObtainDeserializer(contentType);

            return deserializer.Read<T>(parsedText);
        }

        public dynamic DecodeToDynamic(string input, string contentType)
        {
            var parsedText = VerifyNullOrEmpty(input);

            var deserializer = ObtainDeserializer(contentType);

            return deserializer.Read(parsedText);
        }

        private IDataReader ObtainDeserializer(string contentType)
        {
            var deserializer = _dataReaderProvider.Find(contentType);


            if (deserializer == null)
            {
                throw new SerializationException("The encoding requested does not have a corresponding decoder");
            }
            return deserializer;
        }

        private static string VerifyNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            return input;
        }
    }
}
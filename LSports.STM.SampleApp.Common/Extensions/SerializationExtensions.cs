using LSports.STM.SampleApp.Common.Enums;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Extensions
{
    public static class SerializationExtensions
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> XmlSerializers = new ConcurrentDictionary<Type, XmlSerializer>();

        public static T Deserialize<T>(this byte[] input, FormatType formatType)
        {
            if (formatType == FormatType.Protobuf)
            {
                return input.DeserializeProtoBuf<T>();
            }
            else
            {
                string rawData = Encoding.UTF8.GetString(input);

                switch (formatType)
                {
                    case FormatType.Json:
                        return rawData.DeserializeJson<T>();
                    case FormatType.Xml:
                        return input.DeserializeXml<T>();
                    default:
                        return default(T);
                }
            }
        }

        private static T DeserializeXml<T>(this byte[] input)
        {
            var xmlSerializer = XmlSerializers.GetOrAdd(typeof(T), type => new XmlSerializer(typeof(T)));

            using (MemoryStream stream = new MemoryStream(input))
            {
                return (T)xmlSerializer.Deserialize(stream);
            }
        }

        private static T DeserializeJson<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        private static T DeserializeProtoBuf<T>(this byte[] input)
        {
            using (MemoryStream stream = new MemoryStream(input))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}

using System;
using System.Net;

namespace LSports.STM.SampleApp.Common.Extensions
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class GZipWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri url)
        {
            var request = (HttpWebRequest)base.GetWebRequest(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }
    }
}

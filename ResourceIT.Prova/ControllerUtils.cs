using ResourceIT.Prova;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ResourceIT.ProvaCSharp
{
    public class ControllerUtils
    {
        public static HttpResponseMessage Ok(MemoryStream stream, string fileName, ContentType contentType = ContentType.BIN)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType.ToValue());

            return result;
        }



    }
}
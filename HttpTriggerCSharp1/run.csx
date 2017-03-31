#r "DocumentFormat.OpenXml.dll"
#r "OpenXML.dll"

using System.Net;
using OpenXML;
using System.Net.Http.Headers;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    string json = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "json", true) == 0)
        .Value;
    log.Info("JSON: " + json + "-");
    string root = "D:\\home\\site\\wwwroot\\HttpTriggerCSharp1";

    byte[] file = OpenXML.GeneratePPTX.generatePPTX("D:\\home\\site\\wwwroot\\HttpTriggerCSharp1\\Proposal.pptx", json, root);
    
    var result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new ByteArrayContent(file);
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") 
        { FileName = "file.pptx" };
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.presentationml.presentation");

    return result;
}
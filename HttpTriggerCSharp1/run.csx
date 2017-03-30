#r "DocumentFormat.OpenXml.dll"
#r "OpenXML.dll"

using System.Net;
using OpenXML;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    byte[] file = OpenXML.GeneratePPTX.generatePPTX(".\\Proposal.pptx");
    
    return req.CreateResponse(HttpStatusCode.OK, file);
}
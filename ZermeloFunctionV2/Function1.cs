using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Cloud.Dialogflow.V2;
using Google.Apis.Auth.OAuth2;

namespace ZermeloFunctionV2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            WebhookRequest data = JsonConvert.DeserializeObject<WebhookRequest>(requestBody);

            var token = new FileDataStore("Google.Apis.Auth").GetAsync<TokenResponse>("user");
            IntentsClient clnt = IntentsClient.Create();

            var gcred = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

            
            var dayOfWeek = data.queryResult.parameters.dayofweek;
            var leerling = data.queryResult.parameters.leerling;
            var action = data.queryResult.parameters.tijd;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

        
    }
}

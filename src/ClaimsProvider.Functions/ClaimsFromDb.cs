using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ClaimsProvider.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ClaimsProvider.Functions
{
    public class ClaimsFromDb
    {
        private readonly ClaimsProviderContext _context;

        public ClaimsFromDb(ClaimsProviderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [FunctionName(nameof(ClaimsFromDb))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger logger)
        {
            logger.LogInformation("Starting custom claims lookup...");
            string uid = req.Query["uid"];
            if (uid is null)
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                uid = data?.uid;
                if (uid is null)
                {
                    logger.LogWarning("Client did not provide 'uid' parameter.");
                    return new BadRequestObjectResult("Please provide a 'uid' on the query string or in the request body");
                }
            }

            logger.LogInformation("Looking up custom claims for {Uid}.", uid);
            var profile = _context.UserProfiles.SingleOrDefault(u => u.UserIdentifier == uid);
            if (profile is null)
            {
                logger.LogWarning("UserIdentifier '{Uid}' not found.", uid);
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return new OkObjectResult(
                new
                {
                    Version = "1.0.0",
                    Status = (int)HttpStatusCode.OK,
                    profile.CustomerNumber,
                    CustomerStatus = profile.Status.ToString()
                });
        }
    }
}

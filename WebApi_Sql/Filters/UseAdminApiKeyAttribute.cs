using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Sql.Filters
{

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class UseAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>("AdminApiKey");


            // skriv i postman under headers "key":code och i "value":aMOkciBoYXIgamFnIGVuIGFubmFuIGZyYXM    (ADMIN API KEY)
            if (!context.HttpContext.Request.Headers.TryGetValue("code", out var code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }

        /*  
                HEADERS
                --------------------------------------------------------------------
                ContentType         "Content-Type": "application/json"
                Accept              "accept": "text/plain"
                Code                "code": "aMOkciBoYXIgamFnIGVuIGFubmFuIGtvZCBzbnV0dA=="
        */
    }
}

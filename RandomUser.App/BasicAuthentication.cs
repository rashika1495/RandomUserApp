using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace RandomUser.App
{
    public class BasicAuthentication : Attribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Extract credentials
                string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                byte[] decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
                string[] credentials = Encoding.UTF8.GetString(decodedBytes).Split(':', 2);
                string username = credentials[0];
                string password = credentials[1];

                // Check if credentials match
                if (username == "randomuser" && password == "Password@123")
                {
                    // Credentials are valid, continue with the request
                    return Task.CompletedTask;
                }
            }

            // Unauthorized if no or invalid credentials
            context.Result = new UnauthorizedResult();
            return Task.CompletedTask;
        }
    }
}

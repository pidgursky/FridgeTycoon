using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace FT.Services.UserClaimService
{
    public class UserClaimService : IUserClaimService
    {
        public UserClaimService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public Guid UserId
        {
            get;            

        }
    }
}

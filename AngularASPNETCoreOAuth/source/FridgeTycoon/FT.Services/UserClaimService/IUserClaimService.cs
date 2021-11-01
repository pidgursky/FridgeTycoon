using FT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Services.UserClaimService
{
    public interface IUserClaimService
    {
        Guid UserId { get; }
    }
}

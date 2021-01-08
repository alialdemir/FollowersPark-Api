using Microsoft.EntityFrameworkCore;
using System;

namespace FollowersPark.DataAccess
{
    public interface IDbContextFactory : IDisposable
    {
        DbContext Init();
    }
}
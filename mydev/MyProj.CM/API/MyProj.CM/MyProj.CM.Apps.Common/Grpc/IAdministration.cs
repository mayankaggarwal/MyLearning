using MyProj.CM.Common.Contracts.Data.Authorization;
using MyProj.CM.Common.Contracts.Data.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Grpc
{
    public interface IAdministration
    {
        RetailClient GetMarket(int id);
        int? ResolveMarketByCode(string marketCode);
        IEnumerable<RetailClient> GetAllMarkets();
        UserDetails GetUserDetails(string userName, long marketId);
        AppRole[] GetUserClaims(UserDetails userDetails);
        UserDetails GetUserDetailsWithRoleAndPermission(string userName);
    }
}

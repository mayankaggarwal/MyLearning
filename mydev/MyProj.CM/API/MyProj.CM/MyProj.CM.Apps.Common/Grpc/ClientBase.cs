using Grpc.Core;
using MyProj.CM.Apps.Common.Session;
using MyProj.CM.Common.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Grpc
{
    public class ClientBase
    {
        private readonly IUserPrincipal _userPrincipal;
        private readonly IJwtTokenService _jwtTokenService;

        protected ClientBase(IUserPrincipal userPrincipal, IJwtTokenService jwtTokenService)
        {
            _userPrincipal = userPrincipal;
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        private string GetDomainServiceToken()
        {
            return _jwtTokenService.SignToken(new Dictionary<JwtConstants, string>()
            {
                {JwtConstants.UserId, _userPrincipal.AccountId.ToString() },
                {JwtConstants.UserName, _userPrincipal.UserName },
                {JwtConstants.Market, _userPrincipal.Market.ToString() },
                {JwtConstants.Client, _userPrincipal.Client.ToString() },
                {JwtConstants.Type, _userPrincipal.Type },
                {JwtConstants.PreferredLanguageId, _userPrincipal.PreferredLanguageId },
            });
        }

        protected Metadata GetPerCallMetadata()
        {
            return new Metadata { new Metadata.Entry("Authorization", GetDomainServiceToken()) };
        }
    }
}

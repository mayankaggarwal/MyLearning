using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MyProj.CM.Apps.Common.Session;
using MyProj.CM.Common.Contracts.Data.Authorization;
using MyProj.CM.Common.Contracts.Data.Client;
using MyProj.CM.Common.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Apps.Common.Grpc
{
    public class Administration : ClientBase, IAdministration
    {
        private readonly myproj.CM.Administration.Contract.Messages.AdministrationService.AdministrationServiceClient Client;
        private readonly IMapper _mapper;

        public Administration(myproj.CM.Administration.Contract.Messages.AdministrationService.AdministrationServiceClient client
            //, IMapper mapper
            ,IUserPrincipal userPrincipal, IJwtTokenService jwtTokenService):base(userPrincipal,jwtTokenService)
        {
            Client = client;
            //_mapper = mapper;
        }
        public IEnumerable<RetailClient> GetAllMarkets()
        {
            return new List<RetailClient> {
                new RetailClient
                {
                    CultureCode="EN-GB",
                    Description="Tesco United Kingdom",
                    Id = 14,
                    MarketSiteCode = "Tesco_UK",
                    Name = "Tesco UK",
                    PrimaryLanguageId = 1,
                } 
            };

            //return Client.GetAllMarkets(new Empty()).RetailClient.Select(m => m.Map<RetailClient>(m));
        }

        public RetailClient GetMarket(int id)
        {
            throw new NotImplementedException();
        }

        public AppRole[] GetUserClaims(UserDetails userDetails)
        {
            throw new NotImplementedException();
            //var data = Client.GetUserClaims(userDetails, GetPerCallMetadata());
        }

        public UserDetails GetUserDetails(string userName, long marketId)
        {
            return new UserDetails
            {
                ClientId = 10001,
                ClientType = CM.Common.Contracts.Types.ClientType.Sunnhumby,
                Email = "mayank.aggarwal@gmail.com",
                FullName = "Mayank Aggarwal",
                Group = "ABC",
                Id = 10001,
                IsSupplier = false,
                MarketId = 14,
                Name = "mayankgg",
                PreferredLanguageId = 1,
                AppRoles = new AppRole[]
                {
                    new AppRole
                    {
                        Application = "OfferManager",
                        Role = "Media Admin",
                       Claims = new List<Claim>
                       {
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Nominations",
                               Permission = "Manage"
                           },
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Audiences",
                               Permission = "Manage"
                           },
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Dashboard",
                               Permission = "Manage"
                           },
                       }
                    },
                    new AppRole
                    {
                        Application = "EventManager",
                        Role = "Media Admin",
                       Claims = new List<Claim>
                       {
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Events",
                               Permission = "Manage"
                           },
                       }
                    }
                }
            };
        }

        public UserDetails GetUserDetailsWithRoleAndPermission(string userName)
        {
            var test = GetPerCallMetadata();
            return new UserDetails
            {
                ClientId = 10001,
                ClientType = CM.Common.Contracts.Types.ClientType.Sunnhumby,
                Email = "mayank.aggarwal@gmail.com",
                FullName = "Mayank Aggarwal",
                Group = "ABC",
                Id = 10001,
                IsSupplier = false,
                MarketId = 14,
                Name = "mayankgg",
                PreferredLanguageId = 1,
                AppRoles = new AppRole[]
                {
                    new AppRole
                    {
                        Application = "OfferManager",
                        Role = "Media Admin",
                       Claims = new List<Claim>
                       {
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Nominations",
                               Permission = "Manage"
                           },
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Audiences",
                               Permission = "Manage"
                           },
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Dashboard",
                               Permission = "Manage"
                           },
                       }
                    },
                    new AppRole
                    {
                        Application = "EventManager",
                        Role = "Media Admin",
                       Claims = new List<Claim>
                       {
                           new Claim
                           {
                               ClientType = "",
                               Feature = "",
                               IsGrant = true,
                               Module = "Events",
                               Permission = "Manage"
                           },
                       }
                    }
                }
            };
        }

        public int? ResolveMarketByCode(string marketCode)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClient(int clientId)
        {
            return _mapper.Map<Client>(await Client.GetClientAsync(new Int32Value { Value = clientId }, GetPerCallMetadata()));
        }
    }
}

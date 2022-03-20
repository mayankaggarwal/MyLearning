using MyProj.CM.Apps.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProj.CM.Apps.Common.ModelBuilder
{
    public static class MarketHelper
    {
        public static StaticMarketInfo ToModel(this MyProj.CM.Common.Contracts.Data.Client.RetailClient mkt)
        {
            return new StaticMarketInfo
            {
                Id = mkt.Id,
                Name = mkt.Name,
                Code = mkt.MarketSiteCode,
                CultureCode = mkt.CultureCode,
                PrimaryLanguageId = mkt.PrimaryLanguageId,
                SecondaryLanguageId = mkt.SecondaryLanguageId,
                PrimaryLanguage = new TranslationLanguage
                {
                    Code = "EN"
                }
            };
        }

        public static UserInfo ToUserInfoModel(this MyProj.CM.Common.Contracts.Data.Authorization.UserDetails contract)
        {
            return new UserInfo
            {
                PreferredLanguageId = contract.PreferredLanguageId,
                MailReceivePreference = contract.MailReceivePreferrence,
                AppRoles = contract.AppRoles?.Select(x => x.ToModel()).ToArray()
            };
        }

        public static AppRole ToModel(this MyProj.CM.Common.Contracts.Data.Authorization.AppRole contract)
        {
            return new AppRole
            {
                Application = contract.Application,
                Role = contract.Role,
                Claims = contract.Claims?.Select(x => x.ToModel())
            };
        }

        public static Claim ToModel(this MyProj.CM.Common.Contracts.Data.Authorization.Claim contract)
        {
            return new Claim
            {
                Module = contract.Module,
                Feature = contract.Feature,
                Permission = contract.Permission,
                ClientType = contract.ClientType,
                IsGrant = contract.IsGrant
            };
        }
    }
}

using MyProj.CM.Apps.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProj.CM.Apps.Common.Models
{
    public class UserInfo
    {
        [RegularExpression(ModelValidationConstant.InvalidCharacters, ErrorMessage =ModelValidationConstant.InvalidCharacterErrorMessage)]
        public string FullName { get; set; }
        public string Email { get; set; }
        public AppRole[] AppRoles { get; set; }
        public string HelpSite { get; set; }
        public StaticMarketInfo Market { get; set; }
        public int? PreferredLanguageId { get; set; }
        public bool MailReceivePreference { get; set; }
        public bool IsSupplier { get; set; }
    }
}

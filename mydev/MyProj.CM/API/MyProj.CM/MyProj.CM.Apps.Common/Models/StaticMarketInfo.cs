using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Models
{
    public class StaticMarketInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string CultureCode { get; set; }
        public int PrimaryLanguageId { get; set; }
        public int? SecondaryLanguageId { get; set; }
        public TranslationLanguage PrimaryLanguage { get; set; }
        public TranslationLanguage SecondaryLanguage { get; set; }
    }
}

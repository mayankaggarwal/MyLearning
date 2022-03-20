using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TimeZoneConverter;

namespace MyProj.CM.Common.Contracts.Data.Client
{
    public class RetailClient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MarketSiteCode { get; set; }
        public string CultureCode { get; set; }
        public int PrimaryLanguageId { get; set; }
        public int? SecondaryLanguageId { get; set; }
        private string _timeZone;
        public string TimeZone
        {
            get => IsLinux() ? TZConvert.WindowsToIana(_timeZone) : _timeZone;
            set => _timeZone = value;
        }

        private bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}

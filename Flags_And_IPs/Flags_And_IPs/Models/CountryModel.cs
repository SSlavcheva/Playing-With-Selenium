using System;
using System.Collections.Generic;
using System.Text;

namespace Flags_And_IPs.Models
{
    public class CountryModel
    {
        public CountryModel(string countryName, string capitalname, string countryCode)
        {
            this.CapitalName = capitalname;
            this.CountryName = countryName;
            this.CountryCode = CountryCode;
        }
        public string CountryName { get; set; }
        public string CapitalName { get; set; }
        public string CountryCode { get; set; }
    }
}

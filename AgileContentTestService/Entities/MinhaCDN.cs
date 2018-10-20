using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Entities
{
    [DelimitedRecord("|")]
    public class MinhaCDN
    {
        
        public string ResponseSize { get; set; }
        
        public string StatusCode { get; set; }
        
        public string CacheStatus { get; set; }

        private string httpMethodUriPath;

        
        public string HttpMethodUriPath
        {
            get
            {
                return httpMethodUriPath;
            }
            set
            {
                SetProviderAndHttpMetod(value);
                httpMethodUriPath = value;
            }
        }
        
        public string Provider { get; set; }
        
        public string HttpMethod { get; set; }
        
        public string UriPath { get; set; }

        [FieldConverter(ConverterKind.Decimal)]
        public decimal TimeTaken { get; set; }

        void SetProviderAndHttpMetod(string prop)
        {
            string[] arr = prop.Split(' ');
            this.Provider = arr[0].Substring(1).Trim();
            this.HttpMethod = arr[1].Trim();
        }

    }
}

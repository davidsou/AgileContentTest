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
        [FieldOrder(1)]
        public string ResponseSize { get; set; }
        [FieldOrder(2)]
        public string StatusCode { get; set; }

        [FieldOrder(3)]
        public string CacheStatus { get; set; }


        [FieldOrder(4)]
        public string HttpMethodUriPath { get; set; }



        [FieldOrder(5)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal TimeTaken { get; set; }

     

    }
}

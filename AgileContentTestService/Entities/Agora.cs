using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Entities
{


    public class Agora
    {
        public Header Header { get; set; }
        public List<Campos> Campos { get; set; }
        public Agora(List<MinhaCDN> minhaCDN)
        {

            Header = new Header();
            Header.Date = DateTime.Now;
            Header.Version = "1.0";

            Campos = new List<Campos>();

            Campos = minhaCDN.ConvertAll(x => new Campos
            {
                CacheStatus = x.CacheStatus.Contains("INVALIDATE") ? "REFRESH_HIT" : x.CacheStatus
                , HttpMethod = x.HttpMethodUriPath.Split(' ')[0].Replace('"', ' ').Trim()
                , Provider = "#Minha CDN"
                , ResponseSize = x.ResponseSize
                , StatusCode = x.StatusCode
                , TimeTaken = Math.Round(x.TimeTaken).ToString()
                , UriPath = x.HttpMethodUriPath.Split(' ')[1].Trim()
            });
        }
               
    }

    [FixedLengthRecord()]
    public class Header
    {
        [FieldFixedLength(5)]
        public string Version { get; set; }
        [FieldFixedLength(20)]
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy hh:mm:ss")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#Version: {Version}");
            sb.AppendLine($"#Date: {Date}");
            return sb.ToString();
        }
    }

    [FixedLengthRecord()]
    public class Campos
    {
        [FieldFixedLength(12)]
        public string Provider { get; set; }
        [FieldFixedLength(5)]
        public string HttpMethod { get; set; }
        [FieldFixedLength(5)]
        public string StatusCode { get; set; }
        [FieldFixedLength(20)]
        public string UriPath { get; set; }
        [FieldFixedLength(5)]
        public string TimeTaken { get; set; }
        [FieldFixedLength(5)]
        public string ResponseSize { get; set; }
        [FieldFixedLength(20)]
        public string CacheStatus { get; set; }

        public Campos()
        {

        }



    }

}

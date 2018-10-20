using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Entities
{


    public class Agora
    {
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public List<MinhaCDN> Campos { get; set; }

        public Agora()
        {

        }

        public Agora(string minhaCDNfile)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            return base.ToString();
        }

    }


    public class Campos
    {
        public string Provider { get; set; }
        public string HttpMethod {get;set;}
        public string  StatusCode { get; set; }
        public  string UriPath { get; set; }
        public string TimeTaken { get; set; }
        public string  ResponseSize { get; set; }
        public string CacheStatus { get; set; }

    }
        
}

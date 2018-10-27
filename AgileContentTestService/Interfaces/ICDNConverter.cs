using AgileContentTestDomain.Entities;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Interfaces
{
    public interface ICDNConverter
    {
        List<string> Messages { get; }
        Task<Agora> DownloadConverterAsync(string url, string path);



    }
}

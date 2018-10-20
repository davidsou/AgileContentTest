using AgileContentTestDomain.Entities;
using AgileContentTestDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Services
{
    public class CDNConverter : ICDNConverter
    {
        public Result<TOutput> Converter<TOutput, TInput>(TInput File)
        {
            throw new NotImplementedException();
        }

        public Result<TOutput> ReadFile<TOutput>(string path)
        {
            throw new NotImplementedException();
        }
    }
}

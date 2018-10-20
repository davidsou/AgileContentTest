using AgileContentTestDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Interfaces
{
    public interface ICDNConverter
    {
        
        Result<TOutput> Converter<TOutput, TInput>(TInput File);
        Result<TOutput> ReadFile<TOutput>(string path);

    }
}

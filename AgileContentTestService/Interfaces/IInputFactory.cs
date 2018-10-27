
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTestDomain.Interfaces
{
    public interface IInputFactory
    {
        TInput SelectInputType<TInput>();

    }
}

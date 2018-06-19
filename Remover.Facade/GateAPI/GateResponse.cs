using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.GateAPI
{
   public class GateResponsee<T> where T : new()
    {
        public bool result;
        public T Data;

    }
}

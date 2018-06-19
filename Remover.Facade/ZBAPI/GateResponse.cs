using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.ZBAPI
{
   public class GateResponsee<T> where T : new()
    {
        public T Data;
        public  string Date;

    }
}

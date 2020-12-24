using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_G.K
{
    abstract class AbstractCLass
    {
        public abstract bool IsvalidAdmin(string userName, string password);
        public abstract bool IsvalidUser(string userName, string password);
      
    }
}

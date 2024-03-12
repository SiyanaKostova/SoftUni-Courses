using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public interface ICallable
    {
        string Call(string phoneNumber);
    }
}

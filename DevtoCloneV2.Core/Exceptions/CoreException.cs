using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Exceptions
{
    public abstract class CoreException : Exception
    {
        public CoreException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Exceptions
{
    public class ConflictCoreException : CoreException
    {
        public ConflictCoreException(string message) : base(message) { }
    }
}

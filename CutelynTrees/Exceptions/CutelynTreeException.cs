using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.Exceptions
{
    public class CutelynTreeException : Exception
    {
        public CutelynTreeException() {}
        public CutelynTreeException(string? message) : base(message) {}
        public CutelynTreeException(string? message, Exception? innerException) : base(message, innerException) {}
        protected CutelynTreeException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}

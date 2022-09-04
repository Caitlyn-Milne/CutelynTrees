using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.Exceptions
{
    public class BinaryTreeNodeFormatException : CutelynTreeException
    {
        public BinaryTreeNodeFormatException() { }

        public BinaryTreeNodeFormatException(string? message) : base(message) { }

        public BinaryTreeNodeFormatException(string? message, Exception? innerException) : base(message, innerException) { }

        protected BinaryTreeNodeFormatException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees
{
    public interface ITreeNode<TValue> 
    {
        TValue Value { get; }
        ITreeNode<TValue>? Parent { get; }
        IEnumerable<ITreeNode<TValue>> Children { get; }
    }
}

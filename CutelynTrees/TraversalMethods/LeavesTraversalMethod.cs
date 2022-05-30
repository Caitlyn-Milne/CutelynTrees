using CutelynTrees.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public class LeavesTraversalMethod<TValue> : TraversalMethod<TValue>
    {
        private Stack<ITreeNode<TValue>> stack;

        public LeavesTraversalMethod(ITreeNode<TValue> root) : base(root)
        {
            Reset();
        }

        public override void Dispose()
        {
            Current = null;
            stack.Clear();
            stack = null;
        }

        public override bool MoveNext()
        {
            while (stack.Count != 0)
            {
                var node = stack.Pop();

                if (node.IsLeaf())
                {
                    Current = node;
                    return true;
                }

                var reversed = node.Children.Reverse();
                foreach (var child in reversed)
                {
                    if (child is not null)
                        stack.Push(child);
                }
            }
            return false;
        }

        public override void Reset()
        {
            Current = null;
            stack = new();
            stack.Push(Root);
        }
    }
}

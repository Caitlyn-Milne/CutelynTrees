using CutelynTrees.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public class PreOrderTraversalMethod<TValue> : TraversalMethod<TValue>
    {
        public PreOrderTraversalMethod(ITreeNode<TValue> root) : base(() => new PreOrderTraversalMethodEnumerator<TValue>(root)){ }
    }
    public class PreOrderTraversalMethodEnumerator<TValue> : TraversalMethodEnumerator<TValue>
    {
        private Stack<ITreeNode<TValue>>? stack;
        public PreOrderTraversalMethodEnumerator(ITreeNode<TValue> root) : base(root)
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
            if (stack.Count == 0) return false;
            var node = stack.Pop();
            Current = node;

            var reversed = node.Children.Reverse();
            foreach (var child in reversed)
            {
                if (child is not null)
                    stack.Push(child);
            }
            return true;
        }

        public override void Reset()
        {
            stack = new();
            Current = null;
            stack.Push(Root);
        }
    }
}
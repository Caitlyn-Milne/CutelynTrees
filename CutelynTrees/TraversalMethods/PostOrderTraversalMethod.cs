using CutelynTrees.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public class PostOrderTraversalMethod<TValue> : TraversalMethod<TValue>
    {

        private Stack<ITreeNode<TValue>> stack = new();

        HashSet<ITreeNode<TValue>> seen = new();

        public PostOrderTraversalMethod(ITreeNode<TValue> root) : base(root)
        {
            Reset();
        }

        public override void Dispose()
        {
            Current = null;
            stack.Clear();
            seen.Clear();
            stack = null;
            seen = null;
        }

        public override bool MoveNext()
        {
            while (stack.Count != 0)
            {
                var node = stack.Peek();

                if (node.IsLeaf() || seen.Contains(node))
                {
                    Current = node;
                    seen.Remove(node);
                    stack.Pop();
                    return true;
                }
                else
                {
                    seen.Add(node);
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
            stack = new();
            seen = new();
            Current = null;
            stack.Push(Root);
        }
    }
}
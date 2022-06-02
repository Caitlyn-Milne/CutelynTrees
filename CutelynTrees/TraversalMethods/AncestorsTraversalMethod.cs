using CutelynTrees.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public class AncestorsTraversalMethod<TValue> : TraversalMethod<TValue>
    {
        public AncestorsTraversalMethod(ITreeNode<TValue> root) : base(() => new AncestorsTraversalEnumerator<TValue>(root)) { }
    }
    public class AncestorsTraversalEnumerator<TValue> : TraversalMethodEnumerator<TValue>
    {
        public AncestorsTraversalEnumerator(ITreeNode<TValue> root) : base(root)
        {
            Reset();
        }

        public override void Dispose()
        {
            Current = null;
        }

        public override bool MoveNext()
        {
            if (Current == null)
                Current = Root;

            if (Current?.Parent is null) return false;
            Current = Current.Parent;

            return true;
        }

        public override void Reset()
        {
            Current = null;
        }
    }
}

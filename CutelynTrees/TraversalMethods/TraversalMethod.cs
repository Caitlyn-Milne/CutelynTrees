using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public abstract class TraversalMethodEnumerator<TValue>: IEnumerator<ITreeNode<TValue>>{
        public ITreeNode<TValue> Root;

        public TraversalMethodEnumerator(ITreeNode<TValue> root)
        {
            Root = root;
        }

        protected ITreeNode<TValue>? _current;
        public ITreeNode<TValue>? Current
        {
            get => _current;
            set => _current = value;
        }

        object? IEnumerator.Current => Current;

        public abstract void Dispose();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    public abstract class TraversalMethod<TValue> : IEnumerable<ITreeNode<TValue>>
    {
        Func<TraversalMethodEnumerator<TValue>> makeTraversalMethodEnumator;

        public TraversalMethod(Func<TraversalMethodEnumerator<TValue>> getEnumerator)
        {
            this.makeTraversalMethodEnumator = getEnumerator;
        }

        public IEnumerator<ITreeNode<TValue>> GetEnumerator() => makeTraversalMethodEnumator.Invoke();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.TraversalMethods
{
    public abstract class TraversalMethod<TValue> : IEnumerator<ITreeNode<TValue>>, IEnumerable<ITreeNode<TValue>>
    {

        public ITreeNode<TValue> Root;

        public TraversalMethod(ITreeNode<TValue> root)
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

        public IEnumerator<ITreeNode<TValue>> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

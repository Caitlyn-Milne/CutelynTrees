using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.BinaryTrees
{
    public interface IBinaryTreeNode<TValue, TPriority> : ITreeNode<TValue>
    {
        private static Comparer<TPriority>? _comparer;
        public static Comparer<TPriority> Comparer
        {
            get => _comparer ??= Comparer<TPriority>.Default;
            set => _comparer = value;
        }

        TPriority Priority { get; }

        IBinaryTreeNode<TValue, TPriority>? Left { get; }
        IBinaryTreeNode<TValue, TPriority>? Right { get; }

        public new IEnumerable<IBinaryTreeNode<TValue, TPriority>> Children => (new IBinaryTreeNode<TValue, TPriority>?[] { Left, Right }).NotNull();
        IEnumerable<ITreeNode<TValue>> ITreeNode<TValue>.Children => Children;
    }
}

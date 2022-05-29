using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.BinaryTree
{
    public interface IBinaryTreeNode<TValue> : ITreeNode<TValue>
    {
        IBinaryTreeNode<TValue> Left { get; }
        IBinaryTreeNode<TValue> Right { get; }

        public new IEnumerable<IBinaryTreeNode<TValue>> Children => new IBinaryTreeNode<TValue>[] { Left, Right };
        IEnumerable<ITreeNode<TValue>> ITreeNode<TValue>.Children => Children;
    }
}

using CutelynTrees.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.BinaryTrees
{
    public class BinaryTreeNode<TValue, TPriority> : TreeNode<TValue>, IBinaryTreeNode<TValue, TPriority>
    {
        public static Comparer<TPriority> Comparer => IBinaryTreeNode<TValue, TPriority>.Comparer;

        public BinaryTreeNode(
            TValue value,
            TPriority priority,
            BinaryTreeNode<TValue, TPriority>? left = null,
            BinaryTreeNode<TValue, TPriority>? right = null
        ) : base(value)
        {
            Priority = priority;
            if (left is not null)
            {
                Left = left;
            }
            if (right is not null)
            {
                Right = right;
            }
        }

        IBinaryTreeNode<TValue, TPriority>? _left;
        public IBinaryTreeNode<TValue, TPriority>? Left
        {
            get => _left;
            set
            {
                if (value is null)
                {
                    _left = value;
                    return;
                }
                var comparisonResult = Comparer.Compare(value.Priority, Priority);
                if (comparisonResult > 0)
                {
                    throw new BinaryTreeNodeFormatException("left nodes priority cannot be higher than its parent node.");
                }
                if (comparisonResult == 0)
                {
                    throw new BinaryTreeNodeFormatException("left nodes priority cannot be the same as its parent node");
                }
                _left = value;
            }
        }

        IBinaryTreeNode<TValue, TPriority>? _right;
        public IBinaryTreeNode<TValue, TPriority>? Right
        {
            get => _right;
            set
            {
                if (value is null)
                {
                    _right = value;
                    return;
                }
                var comparisonResult = Comparer.Compare(value.Priority, Priority);
                if (comparisonResult < 0)
                {
                    throw new BinaryTreeNodeFormatException("right nodes priority cannot be smaller than its parent node.");
                }
                if (comparisonResult == 0)
                {
                    throw new BinaryTreeNodeFormatException("right nodes priority cannot be the same as its parent node");
                }
                _right = value;
            }
        }

        public IBinaryTreeNode<TValue, TPriority>? _parent = null;
        public new IBinaryTreeNode<TValue, TPriority>? Parent
        {
            get => _parent;
            set => _parent = value;
        }

        ITreeNode<TValue>? ITreeNode<TValue>.Parent => Parent;

        public TPriority Priority { get; }
    }
}

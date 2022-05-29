using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.BinaryTree
{
    public class BinaryTreeNode<TValue> : IBinaryTreeNode<TValue>
    {
        IBinaryTreeNode<TValue> _left;
        public IBinaryTreeNode<TValue> Left
        {
            get => _left;
            set => _left = value;
        }

        IBinaryTreeNode<TValue> _right;
        public IBinaryTreeNode<TValue> Right
        {
            get => _right;
            set => _right = value;
        }


        TValue _value;
        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public TreeNode<TValue>? _parent = null;
        public TreeNode<TValue>? Parent
        {
            get => _parent;
            set => _parent = value;
        }
        ITreeNode<TValue>? ITreeNode<TValue>.Parent => Parent;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees
{
    public class TreeNode<TValue> : ITreeNode<TValue>
    {
        public TreeNode(TValue value)
        {
            Value = value;
        }

        public TreeNode<TValue>? _parent = null;
        public TreeNode<TValue>? Parent {
            get => _parent;
            set => _parent = value;
        }
        ITreeNode<TValue>? ITreeNode<TValue>.Parent => Parent;

        TValue _value;
        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public List<TreeNode<TValue>> _children = new();

        public List<TreeNode<TValue>> Children
        {
            get => _children;
            set
            {
                _children = value;
                foreach (var child in _children)
                    child.Parent = this;
            }

        }
        IEnumerable<ITreeNode<TValue>> ITreeNode<TValue>.Children => Children;

        public override string ToString() => Value?.ToString() ?? "";


    }
}

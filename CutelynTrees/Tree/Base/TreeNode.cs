using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CutelynTrees
{
    public class TreeNode<TValue> : ITreeNode<TValue>
    {
        public TreeNode(TValue value, params TreeNode<TValue>[] children)
        {
            Value = value;
            Children.CollectionChanged += Children_CollectionChanged;

            foreach (var child in children)
            {
                Children.Add(child);
            }
        }

        private TreeNode<TValue>? _parent = null;
        private ObservableCollection<TreeNode<TValue>> _children = new();
        private TValue _value;

        IEnumerable<ITreeNode<TValue>> ITreeNode<TValue>.Children => Children;
        ITreeNode<TValue>? ITreeNode<TValue>.Parent => Parent;

        public TreeNode<TValue> this[int i]
        {
            get => Children[i];
            set
            {
                Children[i] = value;
            }
        }

        public TreeNode<TValue>? Parent
        {
            get => _parent;
            set => _parent = value;
        }


        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public ObservableCollection<TreeNode<TValue>> Children => _children;

        public override string ToString() => Value?.ToString() ?? "";

        private void Children_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            ChildrenAdded(e);
            ChildrenRemoved(e);
        }

        private void ChildrenAdded(NotifyCollectionChangedEventArgs e)
        {
            var newItems = e?.NewItems;
            if (newItems is null) return;

            foreach (var item in newItems)
            {
                if (item is not TreeNode<TValue> node) continue;
                if (node.Parent is not null)
                {
                    node.Parent.Children.Remove(node);
                }
                node.Parent = this;
            }
        }
        private void ChildrenRemoved(NotifyCollectionChangedEventArgs e)
        {
            var oldItems = e?.OldItems;
            if (oldItems is null) return;

            foreach (var item in oldItems)
            {
                if (item is not TreeNode<TValue> node 
                    || node.Parent != this) continue;

                node.Parent = null;
            }
        }
    }
}
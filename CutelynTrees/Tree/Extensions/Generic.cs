using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.Extensions
{
    public enum TreeTraversalMethod
    {
        PRE_ORDER,
        IN_ORDER,
        POST_ORDER
    }

    public static partial class TreeNodeExtensions
    {
        public static bool IsRoot<TValue>(this ITreeNode<TValue> node) => node.Parent is null;

        public static bool IsLeaf<TValue>(this ITreeNode<TValue> node) => !node.Children.Any() || node.Children is null;

        public static bool IsBranch<TValue>(this ITreeNode<TValue> node) => !node.IsLeaf() || !node.IsRoot();

        public static ITreeNode<TValue>? ToRoot<TValue>(this ITreeNode<TValue>? node)
        {
            if (node is null) return null;
            if (node.IsRoot()) return node;
            return ToRoot(node.Parent);
        }
    }
}

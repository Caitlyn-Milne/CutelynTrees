using CutelynTrees.TraversalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.Extensions
{
    public static partial class TreeNodeExtensions
    {
        public static List<ITreeNode<TValue>> ToAncestors<TValue>(this ITreeNode<TValue> node)
        {
            var list = new List<ITreeNode<TValue>>();
            node.ToAncestors(list);
            return list;
        }
        public static void ToAncestors<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null || node.Parent is null) return;
            result.Add(node.Parent);
            node.Parent.ToAncestors(result);
        }

        public static IEnumerable<ITreeNode<TValue>> AsAncestors<TValue>(this ITreeNode<TValue> node)
        {
            return new AncestorsTraversalMethod<TValue>(node);
        }
    }
}

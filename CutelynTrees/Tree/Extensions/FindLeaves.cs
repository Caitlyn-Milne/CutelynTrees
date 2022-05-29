using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.Extensions
{
    public static partial class TreeNodeExtensions
    {
        public static List<ITreeNode<TValue>> FindLeaves<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.FindLeaves(result);
            return result;
        }
        public static void FindLeaves<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node.IsLeaf())
            {
                result.Add(node);
                return;
            }

            foreach (var child in node.Children)
                child.FindLeaves(result);
        }
    }
}

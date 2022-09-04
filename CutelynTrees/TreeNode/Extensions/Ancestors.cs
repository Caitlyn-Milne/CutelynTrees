
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
            if (node is null) return;
            var current = node.Parent;
            while (current is not null)
            {
                result.Add(current);
                current = current.Parent;
            }
        }

        public static IEnumerable<ITreeNode<TValue>> AsAncestors<TValue>(this ITreeNode<TValue> node) 
        {
            if (node is null) yield break;
            var current = node.Parent;
            while (current is not null) 
            {
                yield return current;
                current = current.Parent;
            }
        }
    }
}

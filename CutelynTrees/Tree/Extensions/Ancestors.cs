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
            if(node is null) return new();

            var result = ToAncestors(node.Parent);
            result.Add(node);

            return result;
        }

        public static IEnumerable<ITreeNode<TValue>> AsAncestors<TValue>(this ITreeNode<TValue> node)
        {
            return new AncestorsTraversalMethod<TValue>(node);
        }
    }
}

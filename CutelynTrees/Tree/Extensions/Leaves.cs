using CutelynTrees.Extensions;
using CutelynTrees.TraversalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.Extensions
{
    public static partial class TreeNodeExtensions
    {
        public static IEnumerable<ITreeNode<TValue>> AsLeaves<TValue>(this ITreeNode<TValue> node)
        {
            return new LeavesTraversalMethod<TValue>(node);
        }

        public static List<ITreeNode<TValue>> ToLeaves<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.ToLeaves(result);
            return result;
        }
        public static void ToLeaves<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node.IsLeaf())
            {
                result.Add(node);
                return;
            }

            foreach (var child in node.Children)
                child.ToLeaves(result);
        }
    }
}

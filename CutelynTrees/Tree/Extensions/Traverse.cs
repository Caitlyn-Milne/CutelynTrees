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
        public static IEnumerable<ITreeNode<TValue>> AsTraversal<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => new PostOrderTraversalMethod<TValue>(node),
                TreeTraversalMethod.IN_ORDER => throw new NotImplementedException(), //TODO create in order traversal method
                _ => new PreOrderTraversalMethod<TValue>(node),
            };
        }

        public static List<ITreeNode<TValue>> ToTraversal<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => node.ToPostOrderTraversal(),
                TreeTraversalMethod.IN_ORDER => node.ToInOrderTraversal(),
                _ => node.ToPreOrderTraversal(),
            };
        }

        public static List<ITreeNode<TValue>> ToPreOrderTraversal<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.ToPreOrderTraversal(result);
            return result;
        }

        public static void ToPreOrderTraversal<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            result.Add(node);
            foreach (var child in node.Children)
                ToPreOrderTraversal(child, result);
        }

        public static List<ITreeNode<TValue>> ToPostOrderTraversal<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.ToPostOrderTraversal(result);
            return result;
        }

        public static void ToPostOrderTraversal<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            foreach (var child in node.Children)
                ToPostOrderTraversal(child, result);
            result.Add(node);
        }

        public static List<ITreeNode<TValue>> ToInOrderTraversal<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.ToInOrderTraversal(result);
            return result;
        }

        public static void ToInOrderTraversal<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            var children = node.Children.ToArray();
            var position = children.Length / 2;

            for (var i = 0; i < position; i++)
                ToInOrderTraversal(children[i], result);

            result.Add(node);

            for (var i = position; i < children.Length; i++)
                ToInOrderTraversal(children[i], result);
        }
    }
}

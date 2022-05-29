using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutelynTrees.Extensions
{
    public static partial class TreeNodeExtensions
    {
        public static List<ITreeNode<TValue>> FindDecendants<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => node.FindDescendantsPostOrder(),
                TreeTraversalMethod.IN_ORDER => node.FindDescendantsInOrder(),
                _ => node.FindDescendantsPreOrder(),
            };
        }

        public static List<ITreeNode<TValue>> FindDescendantsPreOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.FindDescendantsPreOrder(result);
            return result;
        }

        public static void FindDescendantsPreOrder<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            result.Add(node);
            foreach (var child in node.Children)
                FindDescendantsPreOrder(child, result);
        }

        public static List<ITreeNode<TValue>> FindDescendantsPostOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.FindDescendantsPostOrder(result);
            return result;
        }

        public static void FindDescendantsPostOrder<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            foreach (var child in node.Children)
                FindDescendantsPostOrder(child, result);
            result.Add(node);
        }

        public static List<ITreeNode<TValue>> FindDescendantsInOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = new List<ITreeNode<TValue>>();
            node.FindDescendantsInOrder(result);
            return result;
        }

        public static void FindDescendantsInOrder<TValue>(this ITreeNode<TValue> node, List<ITreeNode<TValue>> result)
        {
            if (node is null) return;

            var children = node.Children.ToArray();
            var position = children.Length / 2;

            for (var i = 0; i < position; i++)
                FindDescendantsInOrder(children[i], result);

            result.Add(node);

            for (var i = position; i < children.Length; i++)
                FindDescendantsInOrder(children[i], result);
        }

    }
}

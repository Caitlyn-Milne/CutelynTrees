using CutelynTrees.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.Extensions
{
    public static partial class TreeNodeExtensions
    {
        public static IEnumerable<ITreeNode<TValue>> AsDescendants<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return (method switch
            {
                TreeTraversalMethod.POST_ORDER => AsPostOrderTraversal(node),
                TreeTraversalMethod.IN_ORDER => AsInOrderTraversal(node), 
                _ => AsPreOrderTraversal(node),
            }).Where(n => n != node);
        }

        public static List<ITreeNode<TValue>> ToDescendants<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => node.ToDescendantsPostOrder(),
                TreeTraversalMethod.IN_ORDER => node.ToDescendantsInOrder(),
                _ => node.ToDescendantsPreOrder(),
            };
        }

        public static List<ITreeNode<TValue>> ToDescendantsPreOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = node.ToPreOrderTraversal();
            result.Remove(node);
            return result;
        }

        public static List<ITreeNode<TValue>> ToDescendantsInOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = node.ToInOrderTraversal();
            result.Remove(node);
            return result;
        }

        public static List<ITreeNode<TValue>> ToDescendantsPostOrder<TValue>(this ITreeNode<TValue> node)
        {
            var result = node.ToPostOrderTraversal();
            result.Remove(node);
            return result;
        }
    }
}

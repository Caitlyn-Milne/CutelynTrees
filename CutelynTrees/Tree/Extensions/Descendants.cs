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
        public static IEnumerable<ITreeNode<TValue>> AsDescendants<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => new PostOrderTraversalMethod<TValue>(node).Where(n => n != node),
                TreeTraversalMethod.IN_ORDER => throw new NotImplementedException(), //TODO create in order traversal method
                _ => new PreOrderTraversalMethod<TValue>(node).Where(n => n != node),
            };
        }

        public static List<ITreeNode<TValue>> ToDescendants<TValue>(this ITreeNode<TValue> node, TreeTraversalMethod method = TreeTraversalMethod.PRE_ORDER)
        {
            return method switch
            {
                TreeTraversalMethod.POST_ORDER => node.ToDescendantsPostOrder(),
                TreeTraversalMethod.IN_ORDER => node.ToDescendantsInOrder(),
                _ => node.ToDescendantsPostOrder(),
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
            var result = node.ToDescendantsPostOrder();
            result.Remove(node);
            return result;
        }
    }
}

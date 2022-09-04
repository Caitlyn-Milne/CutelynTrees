using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees.BinaryTrees
{
    public static class BinaryTreeNodeFindExtension //todo rename this
    {

        public static IBinaryTreeNode<TValue, TPriority>? Search<TValue, TPriority>(this IBinaryTreeNode<TValue, TPriority> self, IBinaryTreeNode<TValue, TPriority> target)
        {
            return self.Search(target.Priority);
        }

        public static IBinaryTreeNode<TValue, TPriority>? Search<TValue, TPriority>(this IBinaryTreeNode<TValue, TPriority>? self, TPriority target)
        {
            if (self == null) return null;
            
            var comparer = IBinaryTreeNode<TValue, TPriority>.Comparer;
            var comparisonResult = comparer.Compare(self.Priority, target);

            if (comparisonResult == 0)
            {
                return self;
            }

            if (comparisonResult > 0)
            {
                return Search(self.Left, target);
            }

            return Search(self.Right, target);
        }
    }
}

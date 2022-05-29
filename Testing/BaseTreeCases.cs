using CutelynTrees;
using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    public class BaseTreeCases
    {
        /*
         *  1
         *      2 
         *          3
         *          4
         *      5
         *          6
         *          7
         */
        public TreeNode<int> CreateNodeViaConstructor()
        {
            return new TreeNode<int>(1)
            {
                Children = new List<TreeNode<int>>()
                {
                    new TreeNode<int>(2){
                        Children = new List<TreeNode<int>>(){
                            new TreeNode<int>(3),
                            new TreeNode<int>(4)
                        }
                    },
                    new TreeNode<int>(5){ 
                        Children = new List<TreeNode<int>>(){
                            new TreeNode<int>(6),
                            new TreeNode<int>(7)
                        }
                    },
                }
            };
        }

        [Test]
        public void TestConstructor() {
            var tree = CreateNodeViaConstructor();

            Assert.That(tree.Value == 1);

            var node2 = tree.Children[0];
            Assert.That(node2.Value == 2);
            Assert.That(node2.Children[0].Value == 3);
            Assert.That(node2.Children[1].Value == 4);

            var node5 = tree.Children[1];
            Assert.That(node5.Value == 5);
            Assert.That(node5.Children[0].Value == 6);
            Assert.That(node5.Children[1].Value == 7);
        }

        [Test]
        public void TestFindDecendants()
        {
            var tree = CreateNodeViaConstructor();

            var descendants = tree.FindDecendants(TreeTraversalMethod.PRE_ORDER).ToArray().Select(d => d.Value);
            Assert.That(new int[] { 1, 2, 3, 4, 5, 6, 7 }, Is.EqualTo(descendants));

            descendants = tree.FindDecendants(TreeTraversalMethod.IN_ORDER).ToArray().Select(d => d.Value);
            Assert.That(new int[] { 3, 2, 4, 1, 6, 5, 7 }, Is.EqualTo(descendants));

            descendants = tree.FindDecendants(TreeTraversalMethod.POST_ORDER).ToArray().Select(d => d.Value);
            Assert.That(new int[] { 3, 4, 2, 6, 7, 5, 1 }, Is.EqualTo(descendants));
        }
    }
}

using CutelynTrees;
using CutelynTrees.Extensions;
using CutelynTrees.TraversalMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    public class BasicTreeCases
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
            Assert.That(node2.Value, Is.EqualTo(2));
            Assert.That(node2.Children[0].Value, Is.EqualTo(3));
            Assert.That(node2.Children[1].Value, Is.EqualTo(4));

            var node5 = tree.Children[1];
            Assert.That(node5.Value, Is.EqualTo(5));
            Assert.That(node5.Children[0].Value, Is.EqualTo(6));
            Assert.That(node5.Children[1].Value, Is.EqualTo(7));
        }

        [Test]
        public void TestFindMethods()
        {
            var tree = CreateNodeViaConstructor();

            var descendants = tree.FindDecendants().Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            descendants = tree.FindDecendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

            var leaves = tree.FindLeaves().Select(n => n.Value);
            Assert.That(new int[] { 3, 4, 6, 7 }, Is.EqualTo(leaves));

            /*  descendants = tree.FindDecendants(TreeTraversalMethod.IN_ORDER).Select(d => d.Value);
              Assert.That(new int[] { 3, 2, 4, 1, 6, 5, 7 }, Is.EqualTo(descendants));*/
        }

        [Test]
        public void TestFindMethodsLinq()
        {
            var tree = CreateNodeViaConstructor();

            var firstEven = tree.FindDecendants().First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = tree.FindDecendants().Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(tree.FindDecendants().Any(n => n.Value == 5), Is.True);
        }

        [Test]
        public void TestTraversalMethods() {
            var tree = CreateNodeViaConstructor();

            var descendants = tree.Descendants().Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            descendants = tree.Descendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

            var leaves = tree.Leaves().Select(n => n.Value);
            Assert.That(leaves, Is.EqualTo(new int[] { 3, 4, 6, 7 }));

            var firstEven = tree.FindDecendants().First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));
        }

        [Test]
        public void TestTraversalMethodsLinq()
        {
            var tree = CreateNodeViaConstructor();

            var firstEven = tree.Descendants().First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = tree.Descendants().Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(tree.Descendants().Any(n => n.Value == 5), Is.True);
        }
    }
}

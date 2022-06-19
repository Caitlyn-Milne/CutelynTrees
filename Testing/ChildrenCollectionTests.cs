using CutelynTrees;
using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class ChildrenCollectionTests
    {
        public static TreeNode<int> CreateViaCollection()
        {
            var root = new TreeNode<int>(1);
            var child2 = new TreeNode<int>(2);
            var child3 = new TreeNode<int>(3);
            var child4 = new TreeNode<int>(4);
            var child5 = new TreeNode<int>(5);
            var child6 = new TreeNode<int>(6);
            var child7 = new TreeNode<int>(7);
            var child8 = new TreeNode<int>(8);

            root.Children.Add(child2);
            root.Children.Add(child5);
            root.Children.Add(child8);

            child2.Children.Add(child3);
            child2.Children.Add(child4);

            child5.Children.Add(child6);
            child5.Children.Add(child7);

            root.Children.Remove(child8);

            return root;
        }

        [Test]
        public void CheckTreeNodeCollection()
        {
            var tree = CreateViaCollection();

            Assert.That(tree.Value == 1);

            var node2 = tree[0];
            Assert.That(node2.Value, Is.EqualTo(2));
            Assert.That(node2[0].Value, Is.EqualTo(3));
            Assert.That(node2[1].Value, Is.EqualTo(4));

            var node5 = tree[1];
            Assert.That(node5.Value, Is.EqualTo(5));
            Assert.That(node5[0].Value, Is.EqualTo(6));
            Assert.That(node5[1].Value, Is.EqualTo(7));

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var node8 = tree[2];
            });
        }

        [Test]
        public void MoveTreeTest()
        {
            var tree = CreateViaCollection();

            tree[0].Children.Add(tree[1]);
            /*
            *  1
            *      2 
            *          3
            *          4
            *          5
            *              6
            *              7
            */

            Assert.That(tree.Value == 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var node8 = tree[1];
            });

            var node2 = tree[0];
            Assert.That(node2.Value, Is.EqualTo(2));
            Assert.That(node2[0].Value, Is.EqualTo(3));
            Assert.That(node2[1].Value, Is.EqualTo(4));
            Assert.That(node2[2].Value, Is.EqualTo(5));

            var node5 = node2[2];
            Assert.That(node5[0].Value, Is.EqualTo(6));
            Assert.That(node5[1].Value, Is.EqualTo(7));

            //check parents
            var node7 = node5[1];
            Assert.That(node7.Parent.Value, Is.EqualTo(5));

            var node6 = node5[1];
            Assert.That(node6.Parent.Value, Is.EqualTo(5));
            Assert.That(node5.Parent.Value, Is.EqualTo(2));
            Assert.That(node2.Parent.Value, Is.EqualTo(1));
        }
    }
}
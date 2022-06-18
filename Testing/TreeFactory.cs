using CutelynTrees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class TreeFactory
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
        public static TreeNode<int> CreateViaConstructor()
        {
            return new(1,
                        new(2,
                            new(3),
                            new(4)
                        ),
                        new(5,
                            new(6),
                            new(7)
                        )
                    );
        }

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
        public void CheckTreeNodeConstructor()
        {
            var tree = CreateViaConstructor();

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
        public void CheckTreeNodeCollection()
        {
            var tree = CreateViaCollection();

            Assert.That(tree.Value == 1);

            var node2 = tree.Children[0];
            Assert.That(node2.Value, Is.EqualTo(2));
            Assert.That(node2.Children[0].Value, Is.EqualTo(3));
            Assert.That(node2.Children[1].Value, Is.EqualTo(4));

            var node5 = tree.Children[1];
            Assert.That(node5.Value, Is.EqualTo(5));
            Assert.That(node5.Children[0].Value, Is.EqualTo(6));
            Assert.That(node5.Children[1].Value, Is.EqualTo(7));

            Assert.Throws<ArgumentOutOfRangeException>(() => { 
                var node8 = tree.Children[2]; 
            });
        }
    }
}

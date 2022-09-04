using CutelynTrees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.TreeNode
{
    public class ConstructorTests
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
        public static TreeNode<int> Create()
        {
            return new TreeNode<int>(1,
                        new TreeNode<int>(2,
                            new TreeNode<int>(3),
                            new TreeNode<int>(4)
                        ),
                        new TreeNode<int>(5,
                            new TreeNode<int>(6),
                            new TreeNode<int>(7)
                        )
                    );
        }


        [Test]
        public void CheckTreeNodeConstructor()
        {
            var tree = Create();

            Assert.That(tree.Value == 1);

            var node2 = tree[0];
            Assert.That(node2.Value, Is.EqualTo(2));
            Assert.That(node2[0].Value, Is.EqualTo(3));
            Assert.That(node2[1].Value, Is.EqualTo(4));

            var node5 = tree[1];
            Assert.That(node5.Value, Is.EqualTo(5));
            Assert.That(node5[0].Value, Is.EqualTo(6));
            Assert.That(node5[1].Value, Is.EqualTo(7));
        }


    }
}

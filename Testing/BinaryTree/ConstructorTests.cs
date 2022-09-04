using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutelynTrees.BinaryTrees;
using CutelynTrees.Exceptions;
using NUnit.Framework;

namespace Testing.BinaryTree
{
    internal class ConstructorTests
    {
        /*
        *          3
        *      5 
        *  8
        *              9
        *          10
        *      12
        *          14
        */
        public static BinaryTreeNode<int, int> Create()
        {
            return new BinaryTreeNode<int, int>(8, 8,
                left: new BinaryTreeNode<int, int>(5, 5,
                    left: new BinaryTreeNode<int, int>(3, 3)
                ),
                right: new BinaryTreeNode<int, int>(12, 12,
                    left: new BinaryTreeNode<int, int>(10, 10,
                        left: new BinaryTreeNode<int, int>(9, 9)
                    ),
                    right: new BinaryTreeNode<int, int>(14, 14)
                )
            );
        }

        [Test]
        public void CheckTreeNodeConstructor()
        {
            var binaryTree = Create();
            Assert.That(binaryTree.Value, Is.EqualTo(8));

            var nodeL = binaryTree.Left;
            Assert.That(nodeL.Value, Is.EqualTo(5));

            var nodeLL = nodeL.Left;
            Assert.That(nodeLL.Value, Is.EqualTo(3));

            var nodeLLL = nodeLL.Left;
            Assert.That(nodeLLL, Is.Null);

            var nodeLLR = nodeLL.Right;
            Assert.That(nodeLLR, Is.Null);

            var nodeLR = nodeL.Right;
            Assert.That(nodeLR, Is.Null);

            var nodeR = binaryTree.Right;
            Assert.That(nodeR.Value, Is.EqualTo(12));

            var nodeRL = nodeR.Left;
            Assert.That(nodeRL.Value, Is.EqualTo(10));

            var nodeRLL = nodeRL.Left;
            Assert.That(nodeRLL.Value, Is.EqualTo(9));

            var nodeRLLL = nodeRLL.Right;
            Assert.That(nodeRLLL, Is.Null);

            var nodeRLLR = nodeRLL.Right;
            Assert.That(nodeRLLR, Is.Null);

            var nodeRLR = nodeRL.Right;
            Assert.That(nodeRLR, Is.Null);

            var nodeRR = nodeR.Right;
            Assert.That(nodeRR.Value, Is.EqualTo(14));

            var nodeRRL = nodeRR.Left;
            Assert.That(nodeRRL, Is.Null);

            var nodeRRR = nodeRR.Right;
            Assert.That(nodeRRR, Is.Null);
        }


        [Test]
        public void CheckChildrenCannotBeSame()
        {
            Assert.Throws<BinaryTreeNodeFormatException>(() =>
            {
                new BinaryTreeNode<int, int>(2, 2,
                    left: new BinaryTreeNode<int, int>(2, 2)
                );
            });

            Assert.Throws<BinaryTreeNodeFormatException>(() =>
            {
                new BinaryTreeNode<int, int>(2, 2,
                    right: new BinaryTreeNode<int, int>(2, 2)
                );
            });

            Assert.Throws<BinaryTreeNodeFormatException>(() =>
            {
                new BinaryTreeNode<int, int>(2, 2,
                    left: new BinaryTreeNode<int, int>(2, 2),
                    right: new BinaryTreeNode<int, int>(2, 2)
                );
            });
        }

        [Test]
        public void CheckLeftCannotBeLarger()
        {
            Assert.Throws<BinaryTreeNodeFormatException>(() =>
            {
                new BinaryTreeNode<int, int>(2, 2,
                    left: new BinaryTreeNode<int, int>(3, 3)
                );
            });
        }

        [Test]
        public void CheckRightCannotBeSmaller()
        {
            Assert.Throws<BinaryTreeNodeFormatException>(() =>
            {
                new BinaryTreeNode<int, int>(2, 2,
                    right: new BinaryTreeNode<int, int>(1, 1)
                );
            });
        }
    }
}

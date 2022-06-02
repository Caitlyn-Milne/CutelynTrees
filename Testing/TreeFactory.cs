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
    }
}

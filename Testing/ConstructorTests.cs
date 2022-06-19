using CutelynTrees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
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


        [Test]
        public void CheckTreeNodeConstructor()
        {
            var tree = CreateViaConstructor();

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

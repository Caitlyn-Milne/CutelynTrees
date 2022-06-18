using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class ToMethodsTestCases
    {
        [Test]
        public void CheckFullTraversal()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var traversal = tree.ToTraversal().Select(n => n.Value);
            Assert.That(traversal, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            traversal = tree.ToTraversal(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(traversal, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

            var leaves = tree.ToLeaves().Select(n => n.Value);
            Assert.That(new int[] { 3, 4, 6, 7 }, Is.EqualTo(leaves));

            traversal = tree.ToTraversal(TreeTraversalMethod.IN_ORDER).Select(d => d.Value);
            Assert.That(new int[] { 3, 2, 4, 1, 6, 5, 7 }, Is.EqualTo(traversal));
        }

        [Test]
        public void TestFindMethodsLinq()
        {
            var tree = TreeFactory.CreateViaConstructor();
            var traversal = tree.ToTraversal();

            var firstEven = traversal.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = traversal.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(traversal.Any(n => n.Value == 5), Is.True);
        }
    }
}

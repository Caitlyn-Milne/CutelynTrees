using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class TraversalMethodsTestCases
    {
        [Test]
        public void CheckFullTraversal()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var results = tree.Descendants().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            results = tree.Descendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

            results = tree.Leaves().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 3, 4, 6, 7 }));

            results = tree.Ancestors().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { }));

            results = tree[0][1].Ancestors().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 2, 1 }));
        }

        [Test]
        public void CheckPreOrderLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var descendants = tree.Descendants();

            var firstEven = descendants.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = descendants.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(descendants.Any(n => n.Value == 5), Is.True);
        }

        [Test]
        public void CheckPostOrderLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var descendants = tree.Descendants(TreeTraversalMethod.POST_ORDER);

            var firstEven = descendants.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(4));

            var evenNums = descendants.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 4, 2, 6 }));

            Assert.That(descendants.Any(n => n.Value == 5), Is.True);
        }

        [Test]
        public void CheckLeavesLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var leaves = tree.Leaves();

            var firstEven = leaves.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(4));

            var evenNums = leaves.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 4, 6 }));

            Assert.That(leaves.Any(n => n.Value == 5), Is.False);

            Assert.That(leaves.Any(n => n.Value == 3), Is.True);
        }

        [Test]
        public void CheckAncestorsLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var ancestors = tree[0][1].Ancestors();

            var firstEven = ancestors.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = ancestors.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2 }));

            Assert.That(ancestors.Any(n => n.Value == 5), Is.False);

            Assert.That(ancestors.Any(n => n.Value == 2), Is.True);
        }
    }
}

using CM4_Core.DataStructureInterfaces;
using CM4_Core.DataStructures;

namespace CM4_Core_UnitTest.DataStructureTests
{
    public record MockGuid : GuidBaseClass { }
    [TestClass]
    public class LedgerTests
    {
        [TestMethod]
        public void CanCreateLedger()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
        }

        [TestMethod]
        public void InitialSizeIsZero()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            Assert.AreEqual(L.Size(), 0);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(20)]
        public void SizeAfterAddingNRecordsIsN(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            for (int i = 0; i < N; i++)
            {
                MockGuid parent = new MockGuid();
                MockGuid child = new MockGuid();
                L.Add(parent, child);
            }
            Assert.AreEqual(L.Size(), N);
        }

        [TestMethod]
        public void LedgerContainsParentAfterAdding()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            MockGuid child = new MockGuid();
            L.Add(parent, child);
            Assert.IsTrue(L.Contains(parent));
        }

        [TestMethod]
        public void LedgerDoesNotContainParentIfRemoved()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            MockGuid child = new MockGuid();
            L.Add(parent, child);
            L.Remove(parent);
            Assert.IsFalse(L.Contains(parent));
        }

        [TestMethod]
        public void LedgerDoesNotContainParentIfNotAdded()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            Assert.IsFalse(L.Contains(parent));
        }

        [TestMethod]
        public void CanRetrieveChildOfParent()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            MockGuid child = new MockGuid();
            L.Add(parent, child);
            Assert.IsTrue(L.GetChildren(parent).Contains(child));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void ParentOwnsNChildrenAfterNChildrenAdded(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            for (int i = 0; i < N; i++)
            {
                MockGuid child = new MockGuid();
                L.Add(parent, child);
            }
            Assert.AreEqual(L.GetChildren(parent).Count,N);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void ChildHasNParentsAfterNPairsAdded(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid child = new MockGuid();
            for (int i = 0; i < N; i++)
            {
                MockGuid parent = new MockGuid();
                L.Add(parent, child);
            }
            Assert.AreEqual(L.GetParents(child).Count, N);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void AddedChildrenAreSameAsRetrievedChildren(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            HashSet<MockGuid> children = new HashSet<MockGuid>();
            for (int i = 0; i < N; i++)
            {
                MockGuid child = new MockGuid();
                children.Add(child);
                L.Add(parent, child);
            }
            HashSet<MockGuid> Returned_children = L.GetChildren(parent);
            CollectionAssert.AreEqual(children.ToList(), Returned_children.ToList());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        public void AddedParentsAreSameAsRetrivedParents(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid child = new MockGuid();
            HashSet<MockGuid> parents = new HashSet<MockGuid>();
            for (int i = 0; i < N; i++)
            {
                MockGuid parent = new MockGuid();
                parents.Add(parent);
                L.Add(parent, child);
            }
            HashSet<MockGuid> Returned_parents = L.GetParents(child);
            CollectionAssert.AreEqual(parents.ToList(), Returned_parents.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Child cannot be in its own tree of parents")]
        public void ChildCantHaveItselfAsParent()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid child = new MockGuid();
            L.Add(child, child);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        [ExpectedException(typeof(InvalidOperationException), "Child cannot be in its own tree of parents")]
        public void ChildCantExistInItsTreeOfParents(int N)
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid Lastchild = new MockGuid();
            MockGuid Currentchild;
            MockGuid CurrentParent = Lastchild;
            for (int i = 0; i < N; i++)
            {
                Currentchild = new MockGuid();
                L.Add(CurrentParent, Currentchild);
                CurrentParent = Currentchild;
            }
            L.Add(CurrentParent, Lastchild);
        }

        [TestMethod]
        public void RequestingANotAddedItemReturnsEmptySet()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent = new MockGuid();
            Assert.AreEqual(L.GetChildren(parent).Count, 0);
        }

        [TestMethod]
        public void CanRemoveChildFromSpecificParent()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent1 = new MockGuid();
            MockGuid parent2 = new MockGuid();
            MockGuid child = new MockGuid();

            L.Add(parent1, child);
            L.Add(parent2, child);

            Assert.IsTrue(L.GetChildren(parent1).Contains(child));
            Assert.IsTrue(L.GetChildren(parent2).Contains(child));

            L.Remove(parent1, child);

            Assert.IsFalse(L.GetChildren(parent1).Contains(child));
            Assert.IsTrue(L.GetChildren(parent2).Contains(child));
        }

        [TestMethod]
        public void CanAddParentWithNoChildren()
        {
            ILedger<MockGuid, MockGuid> L = new Ledger<MockGuid, MockGuid>();
            MockGuid parent1 = new MockGuid();

            L.Add(parent1);

            Assert.AreEqual(L.GetChildren(parent1).Count, 0);
        }
    }
}

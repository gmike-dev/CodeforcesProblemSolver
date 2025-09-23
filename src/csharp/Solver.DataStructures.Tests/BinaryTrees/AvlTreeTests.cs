using Solver.DataStructures.BinaryTrees;

namespace Solver.DataStructures.Tests.BinaryTrees;

[TestFixture]
public class AvlTreeTests
{
  private AvlTree<int> tree;

  [SetUp]
  public void Setup()
  {
    tree = new AvlTree<int>();
  }

  private static void AssertTreeIsValid(AvlTree<int> t)
  {
    t.IsBalanced().Should().BeTrue();
  }

  private static List<int> InOrderTraversalToList(AvlTree<int> t)
  {
    var result = new List<int>();
    InOrderTraversal(t.GetRoot(), result);
    return result;
  }

  private static void InOrderTraversal(AvlNode<int> node, List<int> result)
  {
    if (node != null)
    {
      InOrderTraversal(node.Left, result);
      result.Add(node.Key);
      InOrderTraversal(node.Right, result);
    }
  }

  [Test]
  public void Insert_SingleElement_ShouldInsertAndMaintainBalance()
  {
    tree.Add(10);

    tree.Contains(10).Should().BeTrue();
    tree.GetTreeHeight().Should().Be(1);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_MultipleElementsInAscendingOrder_ShouldBalanceTree()
  {
    var values = new[] { 10, 20, 30, 40, 50 };

    foreach (var value in values)
      tree.Add(value);

    tree.GetTreeHeight().Should().BeLessOrEqualTo(3);
    values.All(tree.Contains).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_MultipleElementsInDescendingOrder_ShouldBalanceTree()
  {
    var values = new[] { 50, 40, 30, 20, 10 };

    foreach (var value in values)
      tree.Add(value);

    tree.GetTreeHeight().Should().BeLessOrEqualTo(3);
    values.All(tree.Contains).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_DuplicateValues_ShouldNotInsertDuplicates()
  {
    tree.Add(10);
    tree.Add(20);

    tree.Add(10); 

    var elements = InOrderTraversalToList(tree);
    elements.Should().HaveCount(2).And.ContainInOrder((int[])[10, 20]);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_RequiringLeftRotation_ShouldBalanceCorrectly()
  {
    tree.Add(10);
    tree.Add(20);
    tree.Add(30);

    tree.GetTreeHeight().Should().Be(2);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_RequiringRightRotation_ShouldBalanceCorrectly()
  {
    tree.Add(30);
    tree.Add(20);
    tree.Add(10);

    tree.GetTreeHeight().Should().Be(2);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_RequiringLeftRightRotation_ShouldBalanceCorrectly()
  {
    tree.Add(30);
    tree.Add(10);
    tree.Add(20);

    tree.GetTreeHeight().Should().Be(2);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Insert_RequiringRightLeftRotation_ShouldBalanceCorrectly()
  {
    tree.Add(10);
    tree.Add(30);
    tree.Add(20);

    tree.GetTreeHeight().Should().Be(2);
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_NonExistentElement_ShouldThrow()
  {
    tree.Add(10);
    tree.Add(20);

    tree.Remove(30);

    tree.Contains(10).Should().BeTrue();
    tree.Contains(20).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_LeafNode_ShouldRemoveAndBalance()
  {
    tree.Add(10);
    tree.Add(5);
    tree.Add(15);

    tree.Remove(5);

    tree.Contains(5).Should().BeFalse();
    tree.Contains(10).Should().BeTrue();
    tree.Contains(15).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_NodeWithOneChild_ShouldRemoveAndBalance()
  {
    tree.Add(10);
    tree.Add(5);
    tree.Add(15);
    tree.Add(3);

    tree.Remove(5);

    tree.Contains(5).Should().BeFalse();
    tree.Contains(3).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_NodeWithTwoChildren_ShouldRemoveAndBalance()
  {
    tree.Add(10);
    tree.Add(5);
    tree.Add(15);
    tree.Add(3);
    tree.Add(7);

    tree.Remove(5);

    tree.Contains(5).Should().BeFalse();
    tree.Contains(3).Should().BeTrue();
    tree.Contains(7).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_RootNode_ShouldRemoveAndBalance()
  {
    tree.Add(10);
    tree.Add(5);
    tree.Add(15);

    tree.Remove(10);

    tree.Contains(10).Should().BeFalse();
    tree.Contains(5).Should().BeTrue();
    tree.Contains(15).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Remove_MultipleElements_ShouldMaintainBalance()
  {
    var values = new[] { 10, 20, 30, 40, 50, 25 };
    foreach (var value in values)
      tree.Add(value);

    tree.Remove(30);
    tree.Remove(40);

    tree.Contains(30).Should().BeFalse();
    tree.Contains(40).Should().BeFalse();
    values.Except([30, 40]).All(tree.Contains).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void Search_EmptyTree_ShouldReturnFalse()
  {
    tree.Contains(10).Should().BeFalse();
  }

  [Test]
  public void Search_ExistingElement_ShouldReturnTrue()
  {
    tree.Add(10);
    tree.Add(20);

    tree.Contains(10).Should().BeTrue();
    tree.Contains(20).Should().BeTrue();
  }

  [Test]
  public void Search_NonExistingElement_ShouldReturnFalse()
  {
    tree.Add(10);
    tree.Add(20);

    tree.Contains(30).Should().BeFalse();
    tree.Contains(5).Should().BeFalse();
  }

  [Test]
  public void LargeDataSet_ShouldMaintainBalance()
  {
    const int size = 1000;
    var random = new Random(42);
    var values = Enumerable.Range(1, size).ToArray();
    random.Shuffle(values);

    foreach (var value in values)
      tree.Add(value);

    tree.GetTreeHeight().Should().BeLessOrEqualTo((int)Round(Log2(size)) + 2);

    values.All(tree.Contains).Should().BeTrue();
    AssertTreeIsValid(tree);

    var valuesToDelete = values.Where(x => x % 2 == 0).ToList();
    foreach (var value in valuesToDelete)
      tree.Remove(value);

    valuesToDelete.All(x => !tree.Contains(x)).Should().BeTrue();
    values.Except(valuesToDelete).All(tree.Contains).Should().BeTrue();
    AssertTreeIsValid(tree);
  }

  [Test]
  public void InOrderTraversal_ShouldReturnSortedSequence()
  {
    var values = new[] { 50, 30, 70, 20, 40, 60, 80 };
    var expectedSorted = values.OrderBy(x => x).ToArray();

    foreach (var value in values)
      tree.Add(value);

    var inOrderResult = InOrderTraversalToList(tree);

    inOrderResult.Should().BeInAscendingOrder().And.BeEquivalentTo(expectedSorted);
    AssertTreeIsValid(tree);
  }
}

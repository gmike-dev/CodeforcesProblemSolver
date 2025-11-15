namespace Solver.Sorting.Tests;

[TestFixture]
public class SortingTests
{
  private static IEnumerable<int[]> GetTestArrays()
  {
    yield return [5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89];
    yield return [];
    yield return [1];
    yield return [-1, -99];
    yield return [1, 5, -10];
    yield return [6, 5, 4, 1, 2, 3];
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void QuickSortTest(int[] array)
  {
    TestSort(array, Sorting.QuickSort);
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void QuickSortLomutoTest(int[] array)
  {
    TestSort(array, Sorting.QuickSortLomuto);
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void HeapSortTest(int[] array)
  {
    TestSort(array, Sorting.HeapSort);
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void HeapSortGenericTest(int[] array)
  {
    TestSort(array, a => Sorting.HeapSort(a, Comparer<int>.Default.Compare));
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void ShellSortTest(int[] array)
  {
    TestSort(array, Sorting.ShellSort);
  }

  [TestCase(new[] { 2, 0, 2, 1, 1, 0 }, 1, new[] { 0, 0, 1, 1, 2, 2 })]
  [TestCase(new[] { 2, 0, 1 }, 1, new[] { 0, 1, 2 })]
  [TestCase(new[] { 1, 2 }, 1, new[] { 1, 2 })]
  [TestCase(new[] { 6, 1, 0, 1, 2, 3 }, 2, new[] { 1, 0, 1, 2, 3, 6 })]
  public void TreeWayPartitionTest(int[] a, int mid, int[] expected)
  {
    Sorting.TreeWayPartition(a, mid);
    a.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  private static void TestSort(int[] a, Action<int[]> sort)
  {
    var expected = a.OrderBy(x => x).ToArray();
    sort(a);
    a.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}

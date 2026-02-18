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
    yield return [1, 7, 7, -9, 5, -3, -2, 1, 0, 4, 0];
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

  [TestCaseSource(nameof(GetTestArrays))]
  public void MergeSortTest(int[] array)
  {
    TestSort(array, Sorting.MergeSort);
  }

  [TestCaseSource(nameof(GetTestArrays))]
  public void RadixSortTest(int[] array)
  {
    TestSort(array, Sorting.RadixSort);
  }

  [TestCase(new uint[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 })]
  [TestCase(new uint[] { })]
  [TestCase(new uint[] { 1 })]
  [TestCase(new uint[] { 6, 5, 4, 1, 2, 3 })]
  [TestCase(new uint[] { uint.MaxValue, uint.MinValue, 10, uint.MinValue })]
  public void RadixSortUintTest(uint[] array)
  {
    TestSort(array, Sorting.RadixSort);
  }

  [TestCase(new[] { 2, 0, 2, 1, 1, 0 }, 1, new[] { 0, 0, 1, 1, 2, 2 }, 1, 3)]
  [TestCase(new[] { 2, 0, 1 }, 1, new[] { 0, 1, 2 }, 0, 1)]
  [TestCase(new[] { 1, 2 }, 1, new[] { 1, 2 }, -1, 0)]
  [TestCase(new[] { 6, 1, 0, 1, 2, 3 }, 2, new[] { 1, 0, 1, 2, 3, 6 }, 2, 3)]
  public void TreeWayPartitionTest(int[] a, int pivot, int[] expected, 
    int firstGroupEndIndex, int secondGroupEndIndex)
  {
    var (i, j) = Sorting.TreeWayPartition(a, 0, a.Length - 1, pivot);
    a.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    i.Should().Be(firstGroupEndIndex);
    j.Should().Be(secondGroupEndIndex);
  }

  private static void TestSort<T>(T[] a, Action<T[]> sort)
  {
    var expected = a.OrderBy(x => x).ToArray();
    sort(a);
    a.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}

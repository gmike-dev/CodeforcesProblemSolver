using System.Runtime.CompilerServices;
using Solver.DataStructures;

namespace Solver.Sorting;

public static class Sorting
{
  public static void HeapSort(int[] a)
  {
    Heap.Sort(a);
  }

  public static void HeapSort<T>(T[] a, Comparison<T> comparer)
  {
    Heap.Sort(a, comparer);
  }

  public static void QuickSort(int[] a)
  {
    QuickSortHoare(a, 0, a.Length - 1);
  }

  /// <remarks>На отсортированном массиве ведёт себя паршиво.</remarks>
  public static void QuickSortLomuto(int[] a)
  {
    QuickSortLomuto(a, 0, a.Length - 1);
  }

  private static void QuickSortLomuto(int[] a, int l, int r)
  {
    if (l < r)
    {
      var q = LomutoPartition(a, l, r);
      QuickSortLomuto(a, l, q - 1);
      QuickSortLomuto(a, q + 1, r);
    }
  }

  private static void QuickSortHoare(int[] a, int l, int r)
  {
    if (l < r)
    {
      var q = HoarePartition(a, l, r);
      QuickSortHoare(a, l, q);
      QuickSortHoare(a, q + 1, r);
    }
  }

  private static int LomutoPartition(int[] a, int l, int r)
  {
    var pivot = a[r];
    int i = l;
    for (int j = l; j < r; j++)
    {
      if (a[j] < pivot)
      {
        Swap(a, i, j);
        i++;
      }
    }

    Swap(a, i, r);
    return i;
  }

  public static int HoarePartition(int[] a, int l, int r)
  {
    var pivot = a[l + (r - l) / 2];
    var i = l - 1;
    var j = r + 1;
    while (true)
    {
      do
      {
        i++;
      }
      while (a[i] < pivot);

      do
      {
        j--;
      }
      while (a[j] > pivot);

      if (i >= j)
        return j;

      Swap(a, i, j);
    }
  }

  /// <summary>
  /// Dutch national flag problem
  /// https://en.wikipedia.org/wiki/Dutch_national_flag_problem
  /// </summary>
  public static (int, int) TreeWayPartition(int[] a, int l, int r, int pivot)
  {
    var k = l;
    while (k <= r)
    {
      if (a[k] < pivot)
      {
        Swap(a, k, l);
        l++;
        k++;
      }
      else if (a[k] > pivot)
      {
        Swap(a, k, r);
        r--;
      }
      else
      {
        k++;
      }
    }

    return (l - 1, r);
  }

  public static void ShellSort(int[] a)
  {
    var n = a.Length;
    var nextPass = true;
    for (int gap = (n + 1) / 2; nextPass || gap > 1; gap = (gap + 1) / 2)
    {
      nextPass = false;
      for (int i = 0; i + gap < n; i++)
      {
        if (a[i] > a[i + gap])
        {
          Swap(a, i, i + gap);
          nextPass = true;
        }
      }
    }
  }

  public static void RadixSort(int[] array)
  {
    var n = array.Length;
    var unsigned = new uint[n];
    for (var i = 0; i < n; i++)
      unsigned[i] = (uint)(array[i] ^ 0x80000000);

    for (var shift = 0; shift < 32; shift += 8)
      CountingSortByByte(unsigned, shift);

    for (var i = 0; i < n; i++)
      array[i] = (int)(unsigned[i] ^ 0x80000000);
  }
  
  public static void RadixSort(uint[] array)
  {
    for (var shift = 0; shift < 32; shift += 8)
      CountingSortByByte(array, shift);
  }

  private static void CountingSortByByte(uint[] array, int shift)
  {
    var n = array.Length;
    var output = new uint[n];
    var count = new int[256];

    for (var i = 0; i < n; i++)
      count[(array[i] >> shift) & 0xFF]++;

    for (var i = 1; i < 256; i++)
      count[i] += count[i - 1];

    for (var i = n - 1; i >= 0; i--)
    {
      var bucket = (array[i] >> shift) & 0xFF;
      output[--count[bucket]] = array[i];
    }

    Array.Copy(output, array, n);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void Swap(int[] a, int i, int j)
  {
    (a[j], a[i]) = (a[i], a[j]);
  }
}

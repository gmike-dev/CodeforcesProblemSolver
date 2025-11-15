namespace Solver.DataStructures;

public class IndexedMaxHeap<TKey, TValue>(Comparison<TValue> comparer)
{
  private class HeapItem(TKey key, TValue value, int index)
  {
    public readonly TKey Key = key;
    public TValue Value = value;
    public int Index = index;
  }

  private readonly Dictionary<TKey, HeapItem> items = [];
  private readonly List<HeapItem> heap = [];

  public int Count => heap.Count;

  public bool Contains(TKey key) => items.ContainsKey(key);

  public bool TryGetValue(TKey key, out TValue value)
  {
    if (items.TryGetValue(key, out var item))
    {
      value = item.Value;
      return true;
    }

    value = default;
    return false;
  }

  public void Push(TKey key, TValue value)
  {
    var item = new HeapItem(key, value, heap.Count);
    items.Add(key, item);
    heap.Add(item);
    UpHeap(item.Index);
  }

  public bool Remove(TKey key)
  {
    if (!items.Remove(key, out var removedItem))
      return false;
    var index = removedItem.Index;
    var last = heap.Count - 1;
    if (index == last)
    {
      heap.RemoveAt(last);
    }
    else
    {
      Swap(index, last);
      heap.RemoveAt(last);
      UpHeap(index);
      DownHeap(index);
    }

    return true;
  }

  private void Swap(int i, int j)
  {
    (heap[i], heap[j]) = (heap[j], heap[i]);
    heap[i].Index = i;
    heap[j].Index = j;
  }

  public TValue Pop()
  {
    if (heap.Count == 0)
      throw new InvalidOperationException("Heap is empty");
    var top = heap[0];
    var last = heap.Count - 1;
    if (last > 0)
    {
      heap[0] = heap[last];
      heap[0].Index = 0;
      DownHeap(0);
    }

    heap.RemoveAt(last);
    items.Remove(top.Key);
    return top.Value;
  }

  public TValue Top()
  {
    if (heap.Count == 0)
      throw new InvalidOperationException("Heap is empty");
    return heap[0].Value;
  }

  public TValue PushPop(TKey key, TValue value)
  {
    if (heap.Count == 0)
      return value;
    var top = heap[0];
    items.Remove(top.Key);
    var item = new HeapItem(key, value, 0);
    items.Add(key, item);
    heap[0] = item;
    DownHeap(0);
    return top.Value;
  }

  public void ChangeValue(TKey key, TValue newValue)
  {
    var item = items[key];
    var oldValue = item.Value;
    item.Value = newValue;
    switch (comparer(newValue, oldValue))
    {
      case > 0:
        UpHeap(item.Index);
        break;
      case < 0:
        DownHeap(item.Index);
        break;
    }
  }

  private void UpHeap(int i)
  {
    while (i > 0)
    {
      var p = (i - 1) / 2;
      if (comparer(heap[p].Value, heap[i].Value) >= 0)
        break;
      Swap(p, i);
      i = p;
    }
  }

  private void DownHeap(int i)
  {
    while (true)
    {
      var l = 2 * i + 1;
      if (l >= heap.Count)
        break;
      var r = l + 1;
      var largest = l;
      if (r < heap.Count && comparer(heap[r].Value, heap[largest].Value) > 0)
        largest = r;
      if (comparer(heap[largest].Value, heap[i].Value) <= 0)
        break;
      Swap(largest, i);
      i = largest;
    }
  }
}

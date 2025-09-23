namespace Solver.DataStructures.BinaryTrees;

public class AvlTree<T> where T : IComparable<T>
{
  private AvlNode<T> root;

  public void Add(T key) => root = Add(root, key);

  public void Remove(T key) => root = Remove(root, key);

  public bool Contains(T key) => Contains(root, key);

  private static int GetHeight(AvlNode<T> node) => node?.Height ?? 0;

  private static int GetBalance(AvlNode<T> node) => node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);

  private static void UpdateHeight(AvlNode<T> node)
  {
    if (node != null)
      node.Height = 1 + Max(GetHeight(node.Left), GetHeight(node.Right));
  }

  private static AvlNode<T> RightRotate(AvlNode<T> node)
  {
    var left = node.Left;
    if (left is null)
      return node;
    (left.Right, node.Left) = (node, left.Right);
    UpdateHeight(node);
    UpdateHeight(left);
    return left;
  }

  private static AvlNode<T> LeftRotate(AvlNode<T> node)
  {
    var right = node.Right;
    if (right is null)
      return node;
    (right.Left, node.Right) = (node, right.Left);
    UpdateHeight(node);
    UpdateHeight(right);
    return right;
  }

  private static AvlNode<T> Add(AvlNode<T> node, T key)
  {
    if (node == null)
      return new AvlNode<T>(key);

    var cmp = key.CompareTo(node.Key);
    if (cmp < 0)
      node.Left = Add(node.Left, key);
    else if (cmp > 0)
      node.Right = Add(node.Right, key);
    else
      return node;

    UpdateHeight(node);

    switch (GetBalance(node))
    {
      // Left Left Case
      case > 1 when key.CompareTo(node.Left.Key) < 0:
        return RightRotate(node);
      // Right Right Case
      case < -1 when key.CompareTo(node.Right.Key) > 0:
        return LeftRotate(node);
      // Left Right Case
      case > 1 when key.CompareTo(node.Left.Key) > 0:
        node.Left = LeftRotate(node.Left);
        return RightRotate(node);
      // Right Left Case
      case < -1 when key.CompareTo(node.Right.Key) < 0:
        node.Right = RightRotate(node.Right);
        return LeftRotate(node);
      default:
        return node;
    }
  }

  private static AvlNode<T> FindMinNode(AvlNode<T> node)
  {
    var current = node;
    while (current.Left != null)
      current = current.Left;
    return current;
  }

  private static AvlNode<T> Remove(AvlNode<T> node, T key)
  {
    if (node == null)
      return null;

    var cmp = key.CompareTo(node.Key);
    if (cmp < 0)
      node.Left = Remove(node.Left, key);
    else if (cmp > 0)
      node.Right = Remove(node.Right, key);
    else
    {
      if (node.Left != null && node.Right != null)
      {
        var minNode = FindMinNode(node.Right);
        node.Key = minNode.Key;
        node.Right = Remove(node.Right, minNode.Key);
      }
      else
      {
        node = node.Left ?? node.Right;
      }
    }

    if (node == null)
      return null;

    UpdateHeight(node);

    switch (GetBalance(node))
    {
      // Left Left
      case > 1 when GetBalance(node.Left) >= 0:
        return RightRotate(node);
      // Left Right
      case > 1 when GetBalance(node.Left) < 0:
        node.Left = LeftRotate(node.Left);
        return RightRotate(node);
      // Right Right
      case < -1 when GetBalance(node.Right) <= 0:
        return LeftRotate(node);
      // Right Left
      case < -1 when GetBalance(node.Right) > 0:
        node.Right = RightRotate(node.Right);
        return LeftRotate(node);
      default:
        return node;
    }
  }

  private static bool Contains(AvlNode<T> node, T key)
  {
    if (node == null)
      return false;

    return key.CompareTo(node.Key) switch
    {
      0 => true,
      < 0 => Contains(node.Left, key),
      _ => Contains(node.Right, key)
    };
  }

  public int GetTreeHeight() => GetHeight(root);

  public bool IsBalanced() => CheckBalance(root);

  private static bool CheckBalance(AvlNode<T> node)
  {
    if (node == null)
      return true;

    int balance = GetBalance(node);
    return Abs(balance) <= 1 && CheckBalance(node.Left) && CheckBalance(node.Right);
  }

  internal AvlNode<T> GetRoot()
  {
    return root;
  }
}

public class AvlNode<T>(T key) where T : IComparable<T>
{
  public T Key { get; set; } = key;
  public AvlNode<T> Left { get; set; }
  public AvlNode<T> Right { get; set; }
  public int Height { get; set; } = 1;
}

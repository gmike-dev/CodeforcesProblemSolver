namespace Solver.Strings;

public class AhoCorasick
{
  private readonly string[] dictionary;
  private readonly Node root = new();

  private class Node
  {
    public readonly Dictionary<char, Node> Next = new();
    public readonly List<string> Words = [];
    public Node Fail;
    public Node Output;
  }

  public AhoCorasick(string[] dictionary)
  {
    this.dictionary = dictionary;
    BuildTrie();
    BuildFailAndOutputLinks();
  }

  private void BuildTrie()
  {
    foreach (var word in dictionary)
    {
      AddToTrie(word);
    }
  }

  private void BuildFailAndOutputLinks()
  {
    var queue = new Queue<Node>();

    foreach (var node in root.Next.Values)
    {
      node.Fail = root;
      queue.Enqueue(node);
    }

    while (queue.Count > 0)
    {
      Node current = queue.Dequeue();

      foreach ((char c, var child) in current.Next)
      {
        Node failNode = current.Fail;
        while (failNode != null && !failNode.Next.ContainsKey(c))
        {
          failNode = failNode.Fail;
        }
        child.Fail = failNode != null ? failNode.Next[c] : root;
        child.Output = child.Fail.Words.Count > 0 ? child.Fail : child.Fail.Output;

        queue.Enqueue(child);
      }
    }
  }

  public List<(int Position, string Pattern)> FindMatches(string text)
  {
    List<(int Position, string Pattern)> matches = [];
    Node current = root;
    for (int i = 0; i < text.Length; i++)
    {
      char c = text[i];

      while (current != root && !current.Next.ContainsKey(c))
      {
        current = current.Fail;
      }

      current = current.Next.GetValueOrDefault(c, root);

      Node outputNode = current;
      while (outputNode != null)
      {
        foreach (string word in outputNode.Words)
        {
          int startPos = i - word.Length + 1;
          matches.Add((startPos, word));
        }
        outputNode = outputNode.Output;
      }
    }

    return matches;
  }

  private void AddToTrie(string word)
  {
    Node node = root;
    foreach (var c in word)
    {
      if (!node.Next.TryGetValue(c, out var next))
      {
        next = new Node();
        node.Next[c] = next;
      }
      node = next;
    }
    node.Words.Add(word);
  }
}

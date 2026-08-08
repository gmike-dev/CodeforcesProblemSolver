namespace Solver.Strings.Tests;

[TestFixture]
public class AhoCorasickTests
{
  [Test]
  public void Test0()
  {
    var ak = new AhoCorasick(["cat", "dog", "bird", "fish", "rabbit"]);
    ak.FindMatches("catsanddogslovebirdsfishrabbitcat").Should().BeEquivalentTo([
      (0, "cat"),
      (7, "dog"),
      (15, "bird"),
      (20, "fish"),
      (24, "rabbit"),
      (30, "cat")
    ]);
  }

  [Test]
  public void Test1()
  {
    var ak = new AhoCorasick(["he", "she", "his", "hers"]);
    ak.FindMatches("ahishers").Should().BeEquivalentTo([
      (1, "his"),
      (3, "she"),
      (4, "he"),
      (4, "hers")
    ]);
  }

  [Test]
  public void Test2()
  {
    var ak = new AhoCorasick(["a", "aa", "aaa"]);
    ak.FindMatches("aaaa").Should().BeEquivalentTo([
      (0, "a"),
      (0, "aa"),
      (0, "aaa"),
      (1, "a"),
      (1, "aa"),
      (1, "aaa"),
      (2, "a"),
      (2, "aa"),
      (3, "a")
    ]);
  }

  [Test]
  public void Test3()
  {
    var ak = new AhoCorasick(["abc", "def", "ghi"]);
    ak.FindMatches("abcdefghi").Should().BeEquivalentTo([
      (0, "abc"),
      (3, "def"),
      (6, "ghi")
    ]);
  }

  [Test]
  public void Test4()
  {
    var ak = new AhoCorasick(["ab", "aba"]);
    ak.FindMatches("abababa").Should().BeEquivalentTo([
      (0, "ab"),
      (0, "aba"),
      (2, "ab"),
      (2, "aba"),
      (4, "ab"),
      (4, "aba"),
    ]);
  }

  [Test]
  public void Test5()
  {
    var ak = new AhoCorasick(["abc", "bc", "c"]);
    ak.FindMatches("abc").Should().BeEquivalentTo([
      (0, "abc"),
      (1, "bc"),
      (2, "c")
    ]);
  }

  [Test]
  public void Test6()
  {
    var ak = new AhoCorasick(["abc", "bc", "c"]);
    ak.FindMatches("").Should().BeEmpty();
  }

  [Test]
  public void Test7()
  {
    var ak = new AhoCorasick([]);
    ak.FindMatches("abcabcabc").Should().BeEmpty();
  }

  [Test]
  public void Test8()
  {
    var ak = new AhoCorasick(["abcdef"]);
    ak.FindMatches("abc").Should().BeEmpty();
  }

  [Test]
  public void Test9()
  {
    var ak = new AhoCorasick(["a", "b", "c"]);
    ak.FindMatches("abcabcabc").Should().BeEquivalentTo([
      (0, "a"),
      (1, "b"),
      (2, "c"),
      (3, "a"),
      (4, "b"),
      (5, "c"),
      (6, "a"),
      (7, "b"),
      (8, "c"),
    ]);
  }

  [Test]
  public void Test10()
  {
    var ak = new AhoCorasick(["ab", "bc", "cd", "abc", "bcd", "abcd"]);
    ak.FindMatches("abcd").Should().BeEquivalentTo([
      (0, "ab"),
      (0, "abc"),
      (0, "abcd"),
      (1, "bc"),
      (1, "bcd"),
      (2, "cd"),
    ]);
  }
}

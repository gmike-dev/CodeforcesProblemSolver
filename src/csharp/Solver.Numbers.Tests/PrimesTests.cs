namespace Solver.Numbers.Tests;

[TestFixture]
public class PrimesTests
{
  [TestCase(-199, false)]
  [TestCase(-1, false)]
  [TestCase(0, false)]
  [TestCase(1, false)]
  [TestCase(2, true)]
  [TestCase(3, true)]
  [TestCase(4, false)]
  [TestCase(199, true)]
  [TestCase(200, false)]
  public void IsPrimeTests(int x, bool expected)
  {
    Primes.IsPrime(x).Should().Be(expected);
  }
  
  [Test]
  public void PhiTest()
  {
    // https://oeis.org/A000010
    var expected = new[]
    {
      1, 1, 2, 2, 4, 2, 6, 4, 6, 4, 10, 4, 12, 6, 8, 8, 16, 6, 18, 8, 12, 10, 22, 8, 20, 12, 18, 12, 28, 8, 30, 16,
      20, 16, 24, 12, 36, 18, 24, 16, 40, 12, 42, 20, 24, 22, 46, 16, 42, 20, 32, 24, 52, 18, 40, 24, 36, 28, 58, 16,
      60, 30, 36, 32, 48, 20, 66, 32, 44
    };
    for (int i = 1; i <= expected.Length; i++)
    {
      Primes.Phi(i).Should().Be(expected[i - 1], $"phi({i})");
    }
  }
  
  [TestFixture]
  public class SieveTests
  {
    [Test]
    public void Sieve()
    {
      RunTest(Primes.Sieve);
    }

    [Test]
    public void BitSieve()
    {
      RunTest(Primes.BitSieve);
    }

    [Test]
    public void EnhancedSieve()
    {
      RunTest(Primes.EnhancedSieve);
    }

    [Test]
    public void LinearSieve()
    {
      RunTest(Primes.LinearSieve);
    }

    private static void RunTest(Func<int, IReadOnlyList<int>> sieve)
    {
      sieve(0).Should().BeEmpty();
      sieve(1).Should().BeEmpty();
      sieve(2).Should().BeEquivalentTo([2]);
      sieve(3).Should().BeEquivalentTo([2, 3]);
      sieve(101).Should().BeEquivalentTo(
      [
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47,
        53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101
      ]);
      sieve(1000000).Should().HaveCount(78498);
    }
  }
}

namespace Solver.Strings.Tests;

[TestFixture]
public class MatchTests
{
    [Test]
    public void ZFuncTest()
    {
        Match.ZFunc("").Should().BeEmpty();
        Match.ZFunc("a").Should().BeEquivalentTo([0]);
        Match.ZFunc("aaaaa").Should().BeEquivalentTo([0, 4, 3, 2, 1]);
        Match.ZFunc("aaabaab").Should().BeEquivalentTo([0, 2, 1, 0, 2, 1, 0]);
        Match.ZFunc("abacaba").Should().BeEquivalentTo([0, 0, 1, 0, 3, 0, 1]);
    }

    [TestCaseSource(nameof(MatchTestCases))]
    public void ZMatchTest(string t, string s, int expected)
    {
        Match.ZMatch(t, s).Should().Be(expected);
    }

    [Test]
    public void PiFuncTest()
    {
        Match.PiFunc("").Should().BeEmpty();
        Match.PiFunc("a").Should().BeEquivalentTo([0]);
        Match.PiFunc("abcabcd").Should().BeEquivalentTo([0, 0, 0, 1, 2, 3, 0]);
        Match.PiFunc("aabaaab").Should().BeEquivalentTo([0, 1, 0, 1, 2, 2, 3]);
    }

    [TestCaseSource(nameof(MatchTestCases))]
    public void KmpMatchTest(string t, string s, int expected)
    {
        Match.KmpMatch(t, s).Should().Be(expected);
    }

    [Test]
    public void KmpMatchAllTest()
    {
        Match.KmpMatchAll("abcabcd", "abc").Should().BeEquivalentTo([0, 3]);
        Match.KmpMatchAll("abababab", "aba").Should().BeEquivalentTo([0, 2, 4]);
    }

    [TestCaseSource(nameof(MatchTestCases))]
    public void RabinKarp_SingleHash_MatchTest(string t, string s, int expected)
    {
        RabinKarp.SingleHash(t, s).Should().Be(expected);
    }

    [TestCaseSource(nameof(MatchTestCases))]
    public void RabinKarp_DoubleHash_MatchTest(string t, string s, int expected)
    {
        RabinKarp.DoubleHash(t, s).Should().Be(expected);
    }

    private static IEnumerable<TestCaseData> MatchTestCases
    {
        get
        {
            yield return new TestCaseData("abc", "", -1);
            yield return new TestCaseData("", "", -1);
            yield return new TestCaseData("", "abc", -1);
            yield return new TestCaseData("abc", "abcd", -1);
            yield return new TestCaseData("abc", "x", -1);
            yield return new TestCaseData("abcabcd", "abc", 0);
            yield return new TestCaseData("abcabcd", "bc", 1);
            yield return new TestCaseData("abcabcd", "bcd", 4);
            yield return new TestCaseData("abcabcd", "bbcd", -1);
            yield return new TestCaseData("abcdef", "cde", 2);
            yield return new TestCaseData("abcde", "xyz", -1);
        }
    }
}

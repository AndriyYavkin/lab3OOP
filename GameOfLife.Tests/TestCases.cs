using NUnit.Framework;

namespace GameOfLife.Tests;

public static class TestCases
{
    public static IEnumerable<TestCaseData> TestsForGenerations
    {
        get
        {
            yield return new TestCaseData(
                    13,
                    new bool[,]
                    {
                        { false, false, false, false, false },
                        { false, false, false, false, false },
                        { false, true, true, true, false },
                        { false, false, false, false, false },
                        { false, false, false, false, false },
                    })
                .Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false },
                        { false, false, true, false, false },
                        { false, false, true, false, false },
                        { false, false, true, false, false },
                        { false, false, false, false, false },
                    });
            yield return new TestCaseData(
                    11,
                    new bool[,]
                    {
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                        { false, false, true, true, true, false },
                        { false, true, true, true, false, false },
                        { false, false, false, false, false, false },
                        { false, false, false, false, false, false },
                    })
                .Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false },
                        { false, false, false, true, false, false },
                        { false, true, false, false, true, false },
                        { false, true, false, false, true, false },
                        { false, false, true, false, false, false },
                        { false, false, false, false, false, false },
                    });
            yield return new TestCaseData(
                21,
                new bool[,]
                {
                    { false, false, false, false, false, false },
                    { false, true, true, false, false, false },
                    { false, true, false, false, false, false },
                    { false, false, false, false, true, false },
                    { false, false, false, true, true, false },
                    { false, false, false, false, false, false },
                }).Returns(
                new bool[,]
                {
                    { false, false, false, false, false, false },
                    { false, true, true, false, false, false },
                    { false, true, true, false, false, false },
                    { false, false, false, true, true, false },
                    { false, false, false, true, true, false },
                    { false, false, false, false, false, false },
                });
            yield return
                new TestCaseData(
                    1,
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    }).Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    });
            yield return
                new TestCaseData(
                    2,
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    }).Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, true, true, false, true, true, false, false, false },
                        { false, false, true, true, true, false, true, true, true, false, false },
                        { false, false, true, true, true, false, true, true, true, false, false },
                        { false, false, true, true, true, false, true, true, true, false, false },
                        { false, false, true, true, true, false, true, true, true, false, false },
                        { false, false, false, true, true, false, true, true, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    });
            yield return
                new TestCaseData(
                    3,
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    }).Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, true, false, false, false, false, false, true, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, true, false, false, false, false, false, false, false, true, false },
                        { false, true, false, false, false, false, false, false, false, true, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, true, false, false, false, false, false, true, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    });
            yield return
                new TestCaseData(
                    4,
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    }).Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, true, true, true, true, true, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, true, true, true, true, true, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    });
            yield return
                new TestCaseData(
                    5,
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, true, false, true, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    }).Returns(
                    new bool[,]
                    {
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, true, false, false, false, true, false, false, false },
                        { false, false, false, false, true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false, false, false, false, false },
                    });
        }
    }
}

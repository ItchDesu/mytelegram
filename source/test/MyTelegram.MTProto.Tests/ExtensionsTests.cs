using System;
using MyTelegram.Core;
using Shouldly;
using Xunit;

namespace MyTelegram.MTProto.Tests;

public class ExtensionsTest
{
    [Fact]
    public void ToDateTime_Should_Return_Utc_DateTime()
    {
        const int timestamp = 0;

        var dt = timestamp.ToDateTime();

        dt.ShouldBe(DateTime.UnixEpoch);
        dt.Kind.ShouldBe(DateTimeKind.Utc);
    }
}
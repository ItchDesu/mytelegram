using System.Buffers;
using MyTelegram.Schema.Extensions;

namespace MyTelegram.Schema.Serializer;

public class BooleanSerializerTests
{
    [Fact]
    public void Deserialize_ErrorData_Throws_Argument_Exception()
    {
        var value = new byte[] { 1, 2, 3, 4 };
        //var br = new BinaryReader(new MemoryStream(value));
        //var buffer = new ReadOnlySequence<byte>(value);
        ReadOnlyMemory<byte> buffer = value;
        var serializer = CreateSerializer();
        //Assert.Throws<ArgumentException>(() => serializer.Deserialize(ref reader));

        Assert.Throws<ArgumentException>(() =>
        {
            //var reader = new SequenceReader<byte>(new ReadOnlySequence<byte>(value));
            //serializer.Deserialize(ref reader);

            serializer.Deserialize(ref buffer);
        });
    }

    [InlineData(new byte[] { 55, 151, 121, 188 }, false)]
    [InlineData(new byte[] { 181, 117, 114, 153 }, true)]
    [Theory]
    public void DeserializeTest(byte[] value,
        bool expectedValue)
    {
        //var stream = new MemoryStream(value);
        //var br = new BinaryReader(stream);
        var serializer = CreateSerializer();
        //var reader = new SequenceReader<byte>(new ReadOnlySequence<byte>(value));
        ReadOnlyMemory<byte> buffer = value;

        var actualValue = serializer.Deserialize(ref buffer);

        actualValue.ShouldBe(expectedValue);
    }

    [InlineData(false, new byte[] { 55, 151, 121, 188 })]
    [InlineData(true, new byte[] { 181, 117, 114, 153 })]
    [Theory]
    public void SerializeTest(bool value,
        byte[] expectedValue)
    {
        //var stream = new MemoryStream();
        //var bw = new BinaryWriter(stream);
        using var writer = new ArrayPoolBufferWriter<byte>();
        var serializer = CreateSerializer();

        serializer.Serialize(value, writer);

        writer.WrittenSpan.ToArray().ShouldBeEquivalentTo(expectedValue);
    }

    private BooleanSerializer CreateSerializer() => new();
}

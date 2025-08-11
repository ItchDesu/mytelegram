using System.Buffers;
using MyTelegram.Schema.Extensions;

namespace MyTelegram.Schema.Serializer;

public class Int128SerializerTests
{
    [Fact]
    public void SerializeTest()
    {
        var value = "C0CC11F66E1111B8529BB89742D77959".ToBytes();
        //var stream = new MemoryStream();
        //var bw = new BinaryWriter(stream);
        using var writer = new ArrayPoolBufferWriter<byte>();
        var serializer = CreateSerializer();

        serializer.Serialize(value, writer);

        writer.WrittenSpan.ToArray().ShouldBeEquivalentTo(value);
    }

    [Fact]
    public void DeserializeTest()
    {
        var expectedBytes = "C0CC11F66E1111B8529BB89742D77959".ToBytes();
        //var stream = new MemoryStream(expectedBytes);
        //var br = new BinaryReader(stream);
        var serializer = CreateSerializer();
        //var reader = new SequenceReader<byte>(new ReadOnlySequence<byte>(expectedBytes));
        ReadOnlyMemory<byte> buffer = expectedBytes;
        var actualBytes = serializer.Deserialize(ref buffer);

        actualBytes.ShouldBeEquivalentTo(expectedBytes);
    }

    private Int128Serializer CreateSerializer() => new();
}
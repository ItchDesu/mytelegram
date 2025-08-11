namespace MyTelegram.Schema.Serializer;

public class Int32SerializerTests
{
    [Fact]
    public void SerializeTest()
    {
        var expectedValue = new byte[] { 01, 0, 0, 0 };
        //var stream = new MemoryStream();
        //var bw = new BinaryWriter(stream);
        using var writer = new ArrayPoolBufferWriter<byte>();
        var serializer = CreateSerializer();

        serializer.Serialize(1, writer);

        writer.WrittenSpan.ToArray().ShouldBeEquivalentTo(expectedValue);
    }

    [Fact]
    public void DeserializeTest()
    {
        var value = new byte[] { 01, 0, 0, 0 };
        var expectedValue = 1;
        ReadOnlyMemory<byte> buffer = value;
        var serializer = CreateSerializer();

        var actualValue = serializer.Deserialize(ref buffer);

        actualValue.ShouldBeEquivalentTo(expectedValue);
    }

    private Int32Serializer CreateSerializer() => new();
}
namespace MyTelegram.Abstractions;
public record UnencryptedMessage(
    long AuthKeyId,
    string ClientIp,
    string ConnectionId,
    ConnectionType ConnectionType,
    ReadOnlyMemory<byte> MessageData,
    int MessageDataLength,
    long MessageId,
    uint ObjectId,
    Guid RequestId,
    long Date
) : IMtpMessage
{
    public string ConnectionId { get; set; } = ConnectionId;
    public ConnectionType ConnectionType { get; set; } = ConnectionType;
    public string ClientIp { get; set; } = ClientIp;
    public IMemoryOwner<byte>? MemoryOwner { get; set; }
}
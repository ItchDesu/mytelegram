namespace MyTelegram.GatewayServer.BackgroundServices;

public class MessageDataProcessor(IEventBus eventBus)
    : IDataProcessor<UnencryptedMessage>,
        IDataProcessor<EncryptedMessage>, ITransientDependency
{
    public async Task ProcessAsync(EncryptedMessage data)
    {
        try
        {
            await eventBus.PublishAsync(data);
        }
        finally
        {
            data.MemoryOwner?.Dispose();
        }
    }

    public async Task ProcessAsync(UnencryptedMessage data)
    {
        try
        {
            await eventBus.PublishAsync(data);
        }
        finally
        {
            data.MemoryOwner?.Dispose();
        }
    }
}
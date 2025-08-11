// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stories;

///<summary>
/// See <a href="https://corefork.telegram.org/method/stories.getAllReadPeerStories" />
///</summary>
internal sealed class GetAllReadPeerStoriesHandler : RpcResultObjectHandler<MyTelegram.Schema.Stories.RequestGetAllReadPeerStories, MyTelegram.Schema.IUpdates>,
    Stories.IGetAllReadPeerStoriesHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stories.RequestGetAllReadPeerStories obj)
    {
        return Task.FromResult<IUpdates>(new TUpdates
        {
            Updates = new(),
            Chats = new(),
            Users = new(),
            Date = CurrentDate,
        });
    }
}

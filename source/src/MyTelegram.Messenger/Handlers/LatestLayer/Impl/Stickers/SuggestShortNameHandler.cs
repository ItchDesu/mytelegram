using MyTelegram.Schema.Stickers;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Suggests a short name for a given stickerpack name
/// <para>Possible errors</para>
/// Code Type Description
/// 400 TITLE_INVALID The specified stickerpack title is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.suggestShortName" />
///</summary>
internal sealed class SuggestShortNameHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestSuggestShortName, MyTelegram.Schema.Stickers.ISuggestedShortName>,
    Stickers.ISuggestShortNameHandler
{
    protected override Task<MyTelegram.Schema.Stickers.ISuggestedShortName> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestSuggestShortName obj)
    {
        var shortName = obj.Title.Replace(" ", "_").ToLowerInvariant();
        return Task.FromResult<ISuggestedShortName>(new TSuggestedShortName { ShortName = shortName });
    }
}

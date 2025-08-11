// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// HTTP link and embed info of channel message
/// See <a href="https://corefork.telegram.org/constructor/ExportedMessageLink" />
///</summary>
[JsonDerivedType(typeof(TExportedMessageLink), nameof(TExportedMessageLink))]
public interface IExportedMessageLink : IObject
{
    ///<summary>
    /// URL
    ///</summary>
    string Link { get; set; }
}

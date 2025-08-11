// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/colors">color palette </a>.
/// See <a href="https://corefork.telegram.org/constructor/PeerColor" />
///</summary>
[JsonDerivedType(typeof(TPeerColor), nameof(TPeerColor))]
public interface IPeerColor : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/colors">Color palette ID, see here </a> for more info; if not set, the default palette should be used.
    ///</summary>
    int? Color { get; set; }

    ///<summary>
    /// Optional <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji ID</a> used to generate the pattern.
    ///</summary>
    long? BackgroundEmojiId { get; set; }
}

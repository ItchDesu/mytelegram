// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Describes a <a href="https://corefork.telegram.org/api/effects">message effect </a>.
/// See <a href="https://corefork.telegram.org/constructor/AvailableEffect" />
///</summary>
[JsonDerivedType(typeof(TAvailableEffect), nameof(TAvailableEffect))]
public interface IAvailableEffect : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether a <a href="https://corefork.telegram.org/api/premium">Premium</a> subscription is required to use this effect.
    ///</summary>
    bool PremiumRequired { get; set; }

    ///<summary>
    /// Unique effect ID.
    ///</summary>
    long Id { get; set; }

    ///<summary>
    /// Emoji corresponding to the effect, to be used as icon for the effect if <code>static_icon_id</code> is not set.
    ///</summary>
    string Emoticon { get; set; }

    ///<summary>
    /// ID of the document containing the static icon (WEBP) of the effect.
    ///</summary>
    long? StaticIconId { get; set; }

    ///<summary>
    /// Contains the preview <a href="https://corefork.telegram.org/api/stickers#animated-stickers">animation (TGS format )</a>, used for the effect selection menu.
    ///</summary>
    long EffectStickerId { get; set; }

    ///<summary>
    /// If set, contains the actual animated effect <a href="https://corefork.telegram.org/api/stickers#animated-stickers">(TGS format )</a>. If not set, the animated effect must be set equal to the <a href="https://corefork.telegram.org/api/stickers#premium-animated-sticker-effects">premium animated sticker effect</a> associated to the animated sticker specified in <code>effect_sticker_id</code> (always different from the preview animation, fetched thanks to the <a href="https://corefork.telegram.org/constructor/videoSize">videoSize</a> of type <code>f</code> as specified <a href="https://corefork.telegram.org/api/stickers#premium-animated-sticker-effects">here </a>).
    ///</summary>
    long? EffectAnimationId { get; set; }
}

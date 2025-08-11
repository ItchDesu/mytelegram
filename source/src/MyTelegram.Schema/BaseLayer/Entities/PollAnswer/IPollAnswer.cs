// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Indicates a possible answer to a <a href="https://corefork.telegram.org/type/Poll">poll</a>.
/// See <a href="https://corefork.telegram.org/constructor/PollAnswer" />
///</summary>
[JsonDerivedType(typeof(TPollAnswer), nameof(TPollAnswer))]
public interface IPollAnswer : IObject
{
    ///<summary>
    /// Textual representation of the answer (only <a href="https://corefork.telegram.org/api/premium">Premium</a> users can use <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji entities</a> here).
    /// See <a href="https://corefork.telegram.org/type/TextWithEntities" />
    ///</summary>
    MyTelegram.Schema.ITextWithEntities Text { get; set; }

    ///<summary>
    /// The param that has to be passed to <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.
    ///</summary>
    string Option { get; set; }
}

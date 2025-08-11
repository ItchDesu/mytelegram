// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/TodoCompletion" />
///</summary>
[JsonDerivedType(typeof(TTodoCompletion), nameof(TTodoCompletion))]
public interface ITodoCompletion : IObject
{
    int Id { get; set; }
    long CompletedBy { get; set; }
    int Date { get; set; }
}

// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Phone call protocol
/// See <a href="https://corefork.telegram.org/constructor/PhoneCallProtocol" />
///</summary>
[JsonDerivedType(typeof(TPhoneCallProtocol), nameof(TPhoneCallProtocol))]
public interface IPhoneCallProtocol : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether to allow P2P connection to the other participant
    ///</summary>
    bool UdpP2p { get; set; }

    ///<summary>
    /// Whether to allow connection to the other participants through the reflector servers
    ///</summary>
    bool UdpReflector { get; set; }

    ///<summary>
    /// Minimum layer for remote libtgvoip
    ///</summary>
    int MinLayer { get; set; }

    ///<summary>
    /// Maximum layer for remote libtgvoip
    ///</summary>
    int MaxLayer { get; set; }

    ///<summary>
    /// When using <a href="https://corefork.telegram.org/method/phone.requestCall">phone.requestCall</a> and <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a>, specify all library versions supported by the client. <br>The server will merge and choose the best library version supported by both peers, returning only the best value in the result of the callee's <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a> and in the <a href="https://corefork.telegram.org/constructor/phoneCallAccepted">phoneCallAccepted</a> update received by the caller.
    ///</summary>
    TVector<string> LibraryVersions { get; set; }
}

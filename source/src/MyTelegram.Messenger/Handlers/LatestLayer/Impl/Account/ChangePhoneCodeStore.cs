using System.Collections.Generic;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

internal static class ChangePhoneCodeStore
{
    private static readonly Dictionary<(string PhoneNumber, string PhoneCodeHash), string> Codes = new();

    public static void SaveCode(string phoneNumber, string hash, string code)
    {
        Codes[(phoneNumber, hash)] = code;
    }

    public static bool TryGetCode(string phoneNumber, string hash, out string? code)
    {
        var result = Codes.TryGetValue((phoneNumber, hash), out var value);
        code = value;
        return result;
    }

    public static void Remove(string phoneNumber, string hash)
    {
        Codes.Remove((phoneNumber, hash));
    }
}
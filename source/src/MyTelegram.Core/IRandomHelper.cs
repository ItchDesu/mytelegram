namespace MyTelegram.Core;

public interface IRandomHelper
{
    string GenerateRandomString(int length);
    string GenerateRandomNumber(int length);

    void NextBytes(byte[] buffer);

    byte[] NextBytes(int length);
    int NextInt();

    int NextInt(int min,
        int max);

    long NextInt64();
}
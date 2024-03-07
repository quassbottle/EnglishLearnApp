namespace EnglishApplication.Common.Authentication.Hash.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}
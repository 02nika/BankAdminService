using System.Security.Cryptography;
using System.Text;
using PhoneNumbers;

namespace Shared.Extensions;

public static class ComputeExtensions
{
    public static string ComputeSha256Hash(this string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        var builder = new StringBuilder();
        
        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));

        return builder.ToString();
    }

    public static bool PhoneNumberIsValid(this string phoneNumber, string countryCode)
    {
        if (phoneNumber is null) return false;
        
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();

        try
        {
            var number = phoneNumberUtil.Parse(phoneNumber, countryCode);
            return phoneNumberUtil.IsValidNumber(number);
        }
        catch
        {
            return false;
        }
    }
}
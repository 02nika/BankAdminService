using System.Security.Cryptography;
using System.Text;

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
}
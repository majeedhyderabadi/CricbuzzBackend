using System.Net.Mail;
using MatchApi.Domain.Common;

namespace MatchApi.Domain.Entities;

public class AdminUser : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;

    public static AdminUser Create(string firstName, string lastName, string email, string passwordHash, string passwordSalt)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new InvalidOperationException("First name is required.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidOperationException("Last name is required.");
        }

        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
        {
            throw new InvalidOperationException("A valid email address is required.");
        }

        if (string.IsNullOrWhiteSpace(passwordHash) || string.IsNullOrWhiteSpace(passwordSalt))
        {
            throw new InvalidOperationException("Password hash and salt are required.");
        }

        return new AdminUser
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email.Trim().ToLowerInvariant(),
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}

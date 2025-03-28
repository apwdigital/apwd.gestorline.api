namespace Apwd.GestorLine.Domain.Entities.v1.System;

public class User : BaseEntity
{
    public required string UserName { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public int AccountLevel { get; set; }
}

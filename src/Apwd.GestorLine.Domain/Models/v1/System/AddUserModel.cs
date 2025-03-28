namespace Apwd.GestorLine.Domain.Models.v1.System;

public class AddUserModel
{
    public required string CompanyCode { get; set; }
    public required string UserName { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public int AccountLevel { get; set; }
}

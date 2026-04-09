namespace StudentManagementSystem.Api.Models.Auth;

public sealed record LoginResponse(string Token, DateTime ExpiresAtUtc);


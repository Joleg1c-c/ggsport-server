using ggsport.Authentication.Model.Dto;
using ggsport.Authentication.Model.Entity;
using ggsport.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ggsport.Authentication.Services;

public class AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration) : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IConfiguration _configuration = configuration;
    private readonly PasswordHasher<UserModel> _passwordHasher = new();

    public async Task<bool> IsExist(UserModel model)
    {
        var result = await _unitOfWork.UserRepository.GetAsync(filter: u => u.Email == model.Email);
        return result != null;
    }

    public async Task<UserModel?> GetUser(string email)
    {
        return (await _unitOfWork.UserRepository.GetAsync(filter: u => u.Email == email, includeProperties: "Role")).FirstOrDefault();
    }

    public string Register(UserModel model)
    {
        model.Password = _passwordHasher.HashPassword(model, model.Password);
        _unitOfWork.UserRepository.InsertAsync(model);
        _unitOfWork.Save();
        return GenerateJSONWebToken(model);
    }

    private string GenerateJSONWebToken(UserModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim> { new(ClaimTypes.Email, user.Email), new(ClaimTypes.Role, user.Role.Name) };
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task ConfirmEmail(UserModel user)
    {
        user.IsEmailConfirmed = true;
        await _unitOfWork.UserRepository.UpdateAsync(user);
        _unitOfWork.Save();
    }

    public string? Login(UserModel? user, LoginModel model)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
        if (result != PasswordVerificationResult.Success) return null;
        return GenerateJSONWebToken(user);
    }
}

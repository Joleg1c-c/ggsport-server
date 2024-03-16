using AutoMapper;
using ggsport.Authentication.Model.Dto;
using ggsport.Authentication.Model.Entity;
using ggsport.Authentication.Services;
using ggsport.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ggsport.Authentication.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthenticationController(
    ILogger<AuthenticationController> logger,
    IMailService mailService,
    IMapper mapper,
    IAuthenticationService authenticationService
    ) : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger = logger;
    private readonly IAuthenticationService _authenticationService = authenticationService;
    private readonly IMapper _mapper = mapper;
    private readonly IMailService _mailService = mailService;

    [HttpPost(Name = "Register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<UserModel>(model);

            if (await _authenticationService.IsExist(entity))
            {
                ModelState.AddModelError("Exist", "��� ���������� ����� email");
                return UnprocessableEntity(ModelState);
            }
            var token = _authenticationService.Register(entity);

            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Authentication",
                new { userId = model.Email, code = token },
                protocol: HttpContext.Request.Scheme
                );

            await _mailService.SendEmailAsync(model.Email, "Confirm your account",
                $"����������� �����������, ������� �� ������: <a href='{callbackUrl}'>link</a>");
            _logger.LogInformation("�������� ������������: {entity.Email}", entity.Email);
            return Content("��� ���������� ����������� ��������� ����������� ����� � ��������� �� ������, ��������� � ������");
        }
        return UnprocessableEntity(ModelState);
    }

    [HttpGet(Name = "ConfirmEmail")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return NotFound("Error");
        }
        var user = await _authenticationService.GetUser(userId);
        if (user == null)
        {
            return NotFound("Error");
        }
        await _authenticationService.ConfirmEmail(user);
        _logger.LogInformation("����������� ������������: {UserId}", userId);
        return Ok();
    }

    [HttpPut(Name = "Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _authenticationService.GetUser(model.Email);
            if (user != null)
            {
                if (!user.IsEmailConfirmed)
                {
                    ModelState.AddModelError("Confirm", "�� �� ����������� ���� email");
                    return UnprocessableEntity(ModelState);
                }
                var result = _authenticationService.Login(user, model);
                if(result == null)
                {
                    return Forbid();
                }
                _logger.LogInformation("������������ ������������: {user.id} {user.Email}", user.Id, user.Email);
                return Ok(result);
            }
            else
                ModelState.AddModelError("Error", "������������ ����� � (���) ������");
        }
        return UnprocessableEntity(ModelState);
    }
}

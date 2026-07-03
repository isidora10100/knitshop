using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using KnitShop.API.DTOs;
using KnitShop.API.Models;
using KnitShop.API.Repositories;
using KnitShop.API.Services;

namespace KnitShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthController(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
    {
        if (await _userRepository.EmailExistsAsync(dto.Email))
            return Conflict("Korisnik sa ovim email-om već postoji.");

        var user = _mapper.Map<User>(dto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var created = await _userRepository.CreateAsync(user);

        return Ok(BuildAuthResponse(created));
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Pogrešan email ili lozinka.");

        return Ok(BuildAuthResponse(user));
    }

    private AuthResponseDto BuildAuthResponse(User user)
    {
        return new AuthResponseDto
        {
            Token = _tokenService.GenerateAccessToken(user),
            RefreshToken = _tokenService.GenerateRefreshToken(),
            ExpiresAt = _tokenService.GetAccessTokenExpiry(),
            User = _mapper.Map<UserProfileDto>(user)
        };
    }
}

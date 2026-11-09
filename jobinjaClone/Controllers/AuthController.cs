using jobinjaClone.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jobinjaClone.Helpers;
using jobinjaClone.Services;
using jobinjaClone.DTOs.Auth;
using jobinjaClone.Entities;
using Azure.Core;
using jobinjaClone.Constant;

namespace Shop.Api.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class AuthController(ApplicationDbContext context,
    IPasswordHasherService passwordHasherService,
    IJwtService jwtService

    )
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login([FromBody]LoginRequestDto request)
    {
        var normalizedUsername = NameNormaliezer.Normalize(request.Username);

        var user = await context.User
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.username == normalizedUsername);


        if (user == null)
        {
            return BadRequest(ErrorMessage.WrongPassOrUserName);
        }

        var isPasswordCorrect = passwordHasherService
            .Verifiy(user.PasswordHash, request.Password);

        if (!isPasswordCorrect)
        {
            return BadRequest(ErrorMessage.WrongPassOrUserName);
        }

        var token = jwtService.GenerateToken(user);

        return Ok(new
        {
            Token = token,
        });

    }
    [HttpPost]
    public async Task<ActionResult> SignIn([FromBody] SignInRequestDto request)
    {
        var normalizedUsername = NameNormaliezer.Normalize(request.Username);

        var userExists = await context.User
            .AnyAsync(x => x.username == normalizedUsername);

        if (userExists)
        {
            return BadRequest(ErrorMessage.UserNameExist);
        }

        if (request.UserRoleId == null || !request.UserRoleId.Any())
        {
            return BadRequest(ErrorMessage.RolenotEmpty);
        }


        var passwordHash = passwordHasherService.Hash(request.Password);

        List<UserRole> userRoles = new();

        foreach (var roleId in request.UserRoleId)
        {
            var role = await context.Role
                .FirstOrDefaultAsync(x => x.Id == roleId);

            if (role == null)
            {
                return NotFound(ErrorMessage.Rolenotfound);
            }
            userRoles.Add(new UserRole
            {
                RoleId = roleId,
                Role = role
            });
        }

        var user = new User
        {
            Email = request.Email,
            username = normalizedUsername,
            PasswordHash = passwordHash,
            UserRoles = userRoles
        };

        context.User.Add(user);

        await context.SaveChangesAsync();

        var token = jwtService.GenerateToken(user);

        return Ok(new
        {
            Token = token
        });
    }
}
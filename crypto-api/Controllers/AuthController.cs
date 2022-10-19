using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Core.Services;
using Crypto.Data;
using Crypto.Data.Models;
using crypto_api.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace crypto_api.Controllers
{
    [EnableCors("CrosPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;

        public AuthController(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper,AuthService authService)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreateUserDto Signup)
        {
            var newUser = await _authService.Register(Signup);


            return Ok(new RegisterResponse
            {
                Id = newUser.Id,
                Firstname = newUser.FirstName,
                Lastname = newUser.LastName,
                Username = newUser.UserName,
                Email = newUser.Email
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto request)
        {
            var loginResponse = _authService.Login(request.Username, request.Password);
            return Ok(loginResponse);
        }


    }
}

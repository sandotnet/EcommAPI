using AutoMapper;
using EcommAPI.DTOs;
using EcommAPI.Entities;
using EcommAPI.Models;
using EcommAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            userService = new UserService();
            _mapper = mapper;
        }
        //Get: /GetAllUsers
        [HttpGet,Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
                return StatusCode(200, users);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost,Route("Register")]
        public IActionResult AddUser(UserDto userDto)
        {
            try
            {
                User user=_mapper.Map<User>(userDto);
               userService.CreateUser(user);
                return StatusCode(200,user);
               // return Ok(); //return emplty result

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //PUT /EditUser
        [HttpPut,Route("EditUser")]
        public IActionResult EditUser(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                userService.EditUser(user);
                return StatusCode(200, user);
                // return Ok(); //return emplty result

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost,Route("Validate")]
        public IActionResult Validate(Login login)
        {
            try
            {
                User user = userService.ValidteUser(login.Email, login.Password);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}

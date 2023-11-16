using System;
using System.Linq;
using System.Security.Claims;
using btl_web.Constants;
using btl_web.Constants.Statuses;
using btl_web.Dtos;
using btl_web.Exceptions;
using btl_web.Models;
using btl_web.Repositories.Interfaces;
using btl_web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using BCryptNet = BCrypt.Net.BCrypt;

namespace btl_web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpContextAccessor _context;

        public UserService(IUserRepository userRepository, 
            IRoleRepository roleRepository,
            IHttpContextAccessor context)
        {
           _userRepository = userRepository;
           _roleRepository = roleRepository;
           _context = context;
        }


        public UserDto GetUserById(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new DataRuntimeException(StatusNotExist.UserId);
            }

            return new UserDto(user);
        }

        public UserDto GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_IS_EMPTY);
            }

            User user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new DataRuntimeException(StatusNotExist.UserId);
            }

            return new UserDto(user);
        }

        public void saveUserToSession(UserDto user)
        {
            string userString = JsonConvert.SerializeObject(user);
            _context.HttpContext.Session.SetString("user", userString);
        }

        public void removeUserFromSession()
        {
            _context.HttpContext.Session.Remove("user");
        }

        public UserDto getUserFromSession()
        {
            string userString = _context.HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(userString)) return null;

            return JsonConvert.DeserializeObject<UserDto>(userString);
        }

        public UserDto Login(string email, string password)
        {
            User user = _userRepository.GetByEmailAndPassowrd(email, password);
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_OR_PASSWORD_WRONG_FROMAT);
            }

            saveUserToSession(new UserDto(user));


            return new UserDto(user);
        }

        public bool Logout()
        {
            removeUserFromSession();
            return true;
        }

        public UserDto Register(UserDto dto)
        {
            ValidateRegister(dto);

            User user = new User
            {
                Email = dto.Email,
                Password = BCryptNet.HashPassword(dto.Password),
                FullName = dto.FullName,
                Description = dto.Description,
                RoleId = getRoleByEmail(dto.Email).Id,
                Status = "true",
            };

            _userRepository.AddAsync(user);

            return new UserDto(user);
        }

        private Role getRoleByEmail(string email)
        {
            Role? role = null;

            if (email.Contains("@students.hou.edu.vn"))
                role = _roleRepository.GetByName(RoleConfig.STUDENT);
            else if (email.Contains("@hou.edu.vn"))
                role = _roleRepository.GetByName(RoleConfig.TEACHER);

            return role;
        }

        private void ValidateRegister(UserDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email))
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_IS_EMPTY);
            }

            if (string.IsNullOrEmpty(dto.Email))
            {
                throw new DataRuntimeException(StatusWrongFormat.EMAIL_IS_EMPTY);
            }

            if (_userRepository.ExistByEmail(dto.Email))
            {
                throw new DataRuntimeException(StatusExist.EMAIL_IS_EXSIT);
            }


            if (string.IsNullOrEmpty(dto.FullName))
            {
                throw new DataRuntimeException(StatusWrongFormat.FULL_NAME_IS_EMPTY);
            }

            if (string.IsNullOrEmpty(dto.Password))
            {
                throw new DataRuntimeException(StatusWrongFormat.PASSWORD_IS_EMPTY);
            }

            if (string.IsNullOrEmpty(dto.RePassword))
            {
                throw new DataRuntimeException(StatusWrongFormat.RE_PASSWORD_IS_EMPTY);
            }

            if (!string.Equals(dto.Password, dto.RePassword))
            {
                throw new DataRuntimeException(StatusWrongFormat.RE_PASSWORD_NOT_SAME_PASSWORD);
            }
        }
    }
}
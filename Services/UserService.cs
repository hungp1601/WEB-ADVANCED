using System;
using System.Linq;
using System.Security.Claims;
using btl_web.Constants;
using btl_web.Constants.Statuses;
using btl_web.Dtos;
using btl_web.Exceptions;
using btl_web.Models;
using btl_web.Repositories;
using btl_web.Repositories.Interfaces;
using btl_web.Services.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace btl_web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
      
        public UserService(
            IUserRepository userRepository
           
        )
        {
            _userRepository = userRepository;
           
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

        public UserDto Login(string email, string password)
        {
            User user = _userRepository.GetByEmailAndPassowrd(email, password);
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_OR_PASSWORD_WRONG_FROMAT);
            }

            return new UserDto(user);
        }

        public UserDto Register(UserDto dto)
        {
            ValidateRegister(dto);
            User user = new User
            {
                Email = dto.Username,
                Password = BCryptNet.HashPassword(dto.Password),
                FullName = dto.FullName,
                Description = dto.Description,

            };

            //_userRepository.Add(user);

            //Role role = _roleRepository.GetByName(RoleConfig.USER);
            //UserRole userRole = new UserRole
            //{
            //    User = user,
            //    Role = role
            //};

            //_userRoleRepository.Add(userRole);

            return new UserDto(user);
        }

        private void ValidateRegister(UserDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email))
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_IS_EMPTY);
            }

            if (_userRepository.ExistByEmail(dto.Email))
            {
                throw new DataRuntimeException(StatusExist.USERNAME_IS_EXSIT);
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
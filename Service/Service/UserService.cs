using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Models;
using Newtonsoft.Json;
using Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Service.Service
{
    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        protected ITokenService _tokenService;
        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService
            )
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<ApiLinkGamerResponse> InsertUser(UserInsertModel userInsertModel)
        {
            try
            {
                //var modelValidated = userInsertModel.isValid();
                //if (!modelValidated.Valid)
                //    return new ApiLinkGamerResponse(false, modelValidated.Message);

                string userSerialized = JsonConvert.SerializeObject(userInsertModel);
                User? user = JsonConvert.DeserializeObject<User>(userSerialized);

                if (user == null)
                    return new ApiLinkGamerResponse(false, "Invalid Request.");

                user.Password = BC.HashPassword(user.Password);

                bool success = await _userRepository.InsertUser(user);

                if(success)
                    return new ApiLinkGamerResponse(success, "Usuário registrado com succeso.");
                else
                    return new ApiLinkGamerResponse(success, "Ops.. Ocorreu um erro ao registrar usuário.");


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiLinkGamerResponse> Login(UserLoginModel userLoginModel)
        {
            User? user = null;
            if (userLoginModel != null && !string.IsNullOrEmpty(userLoginModel.Email) && !string.IsNullOrEmpty(userLoginModel.Password))
                user = await _userRepository.GetByEmail(userLoginModel.Email, true);
            else
                return new ApiLinkGamerResponse(false, "Usuário ou senha inválidos");

            if(user != null && BC.Verify(userLoginModel.Password, user.Password))
            {
                user.Password = null;
                var userToken = _tokenService.GetToken(user);
                return new ApiLinkGamerResponse(true, "Login efetuado com sucesso.", new {
                    user = user,
                    token = userToken
                });
            }
            else
            {
                return new ApiLinkGamerResponse(false, "Usuário ou senha inválidos");
            }
        }

        public async Task<ApiLinkGamerResponse> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return new ApiLinkGamerResponse(true, users);
            }
            catch (Exception)
            {
                return new ApiLinkGamerResponse(false, "Ops! Ocorreu um erro durante a busca.");
            }
        }
    }
}

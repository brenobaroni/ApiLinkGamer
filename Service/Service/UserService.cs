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

namespace Service.Service
{
    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiLinkGamerResponse> InsertUser(UserInsertModel userInsertModel)
        {
            try
            {
                var modelValidated = userInsertModel.isValid();
                if (!modelValidated.Valid)
                    return new ApiLinkGamerResponse(false, modelValidated.Message);

                string userSerialized = JsonConvert.SerializeObject(userInsertModel);
                User? user = JsonConvert.DeserializeObject<User>(userSerialized);

                if (user == null)
                    return new ApiLinkGamerResponse(false, "Invalid Request.");

                bool success = await _userRepository.InsertUser(user);

                return new ApiLinkGamerResponse(success, "Usuário registrado com succeso.");


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


using FundingApplication.Data;
using FundingApplication.DTO;
using FundingApplication.Models;
using FundingApplication.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FundingApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public ResultDTO<LoginDTO> Login(LoginDTO loginDTO)
        {
            try
            {
                //validation
                if (string.IsNullOrEmpty(loginDTO.Email))
                {
                    return ResultDTO<LoginDTO>.Fail("email can not be null");
                }
                if (string.IsNullOrEmpty(loginDTO.Password))
                {
                    return ResultDTO<LoginDTO>.Fail("password can not be null");
                }

                var userLog = _dbContext.users.FirstOrDefault(x => x.Email.Equals(loginDTO.Email));
                if (userLog == null)
                {
                    return ResultDTO<LoginDTO>.Fail("email dont match");
                }
                else
                {
                    if (userLog.Password != loginDTO.Password)
                    {
                        return ResultDTO<LoginDTO>.Fail("password dont match");
                    }
                }

                return ResultDTO<LoginDTO>.Success(loginDTO);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultDTO<RegisterDTO> Register(RegisterDTO registerDTO)
        {
            try
            {
                //validate
                if (registerDTO is null)
                {
                    return ResultDTO<RegisterDTO>.Fail("object is Null");
                }
                var user = new User
                {
                    Id = new Guid(),
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    age = registerDTO.age,
                    Password = registerDTO.Password,
                    Phone = registerDTO.Phone,
                    StartedDate = DateTime.UtcNow,
                };
                _dbContext.users.Add(user);
                _dbContext.SaveChanges();
                return ResultDTO<RegisterDTO>.Success(registerDTO);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

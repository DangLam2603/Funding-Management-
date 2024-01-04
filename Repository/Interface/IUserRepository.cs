
using FundingApplication.DTO;

namespace FundingApplication.Repository.Interface
{
    public interface IUserRepository
    {
        public ResultDTO<RegisterDTO> Register(RegisterDTO registerDTO);
        public ResultDTO<LoginDTO> Login(LoginDTO loginDTO);
    }
}

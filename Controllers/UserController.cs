using FundingApplication.Data;
using FundingApplication.DTO;
using FundingApplication.Models;
using FundingApplication.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundingApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        private readonly IUserRepository userRepository;

        public UserController(ApplicationDBContext dBContext, IUserRepository userRepository)
        {
            this.dBContext = dBContext;
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index(Guid? id)
        {
            return View(dBContext.users.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(RegisterDTO registerDTO)
        {
            try
            {
                if (registerDTO is null)
                {
                    return BadRequest();
                }
                var userParse = new User
                {
                    Email = registerDTO.Email,
                    Name = registerDTO.Name,
                    Id = Guid.NewGuid(),
                    age = registerDTO.age,
                    Password = registerDTO.Password,
                    Phone = registerDTO.Phone,
                    StartedDate = DateTime.UtcNow,
                };

                await dBContext.AddAsync(userParse);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Detail", "Salary", new { id = userParse.Id });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(LoginDTO loginDTO)
        {
            try
            {
                //validation
                if (string.IsNullOrEmpty(loginDTO.Email))
                {
                    return BadRequest();
                }
                if (string.IsNullOrEmpty(loginDTO.Password))
                {
                    return BadRequest();
                }

                var userLog = dBContext.users.FirstOrDefault(x => x.Email.Equals(loginDTO.Email.Trim()));
                if (userLog == null)
                {
                    return BadRequest();
                }
                else
                {
                    if (userLog.Password != loginDTO.Password.Trim())
                    {
                        return BadRequest();
                    }
                }

                return RedirectToAction("Detail", "Salary", new { id = userLog.Id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}

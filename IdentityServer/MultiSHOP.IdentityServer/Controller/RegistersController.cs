using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiSHOP.IdentityServer.Dtos;
using MultiSHOP.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MultiSHOP.IdentityServer.Controller
{
    [Authorize(IdentityServer4.IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            // Kullanıcı adını kontrol et
            var existingUserByUsername = await _userManager.FindByNameAsync(userRegisterDto.Username);
            if (existingUserByUsername != null)
            {
                return BadRequest("Kullanıcı adı zaten mevcut."); // "Username already exists."
            }

            // E-posta adresini kontrol et
            var existingUserByEmail = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if (existingUserByEmail != null)
            {
                return BadRequest("E-posta adresi zaten mevcut."); // "Email address already exists."
            }

            // Yeni kullanıcı oluştur
            var user = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi."); // "User added successfully."
            }

            // Kayıt sırasında bir hata oluşursa hata mesajlarını döndür
            var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
            return BadRequest($"Bir hata oluştu: {errorMessages}"); // "An error occurred: {errorMessages}"
        }
    }
}

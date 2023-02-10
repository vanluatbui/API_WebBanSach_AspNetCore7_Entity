using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLBanSach_API.Model;
using QLBanSach_API.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace QLBanSach_API.Controller.User_Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }
        private IConfiguration configuration { get; set; }
        private IMapper mapper { get; set; }
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpGet("get-all-user")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllUser()
        {
            try
            {
                var listUser = userManager.Users.ToList();
                var listUserDTO = listUser.Select
                            (
                              emp => mapper.Map<User, TokenModel>(emp)
                            );

                return Ok(new { result = true, data = listUserDTO });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all User successful !" });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(TokenModel tokenModel)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (!await roleManager.RoleExistsAsync("Guest"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Guest"));
                }

                //------------------------------------------------

                User user = mapper.Map<TokenModel, User>(tokenModel);
                user.Id = Guid.NewGuid().ToString();
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                user.PasswordHash = hasher.HashPassword(user, tokenModel.Password);


                var result = await userManager.CreateAsync(user);

                await userManager.AddToRoleAsync(user, "Guest");
               // await userManager.AddToRoleAsync(user, "Admin");

                return Ok(new { result = true, message = "Resister User successful !" });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpPut("update-user")]
        [Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> UpdateUser(TokenModel userModel)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userModel.UserName);

                user.UserName = userModel.UserName; //nếu cần thay đổi Username khác
                user.Email = userModel.Email;
                user.FullName = userModel.FullName;
                user.Gender = userModel.Gender;
                user.BirthDate = userModel.BirthDate;
                user.PhoneNumber = userModel.PhoneNumber;
                user.Address = userModel.Address;

                    await userManager.RemovePasswordAsync(user);
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    user.PasswordHash = hasher.HashPassword(user, userModel.Password);
                

                var result = await userManager.UpdateAsync(user);

                return Ok(new { result = true, message = "Update User successful !" });
            }
            catch
            {
                return Ok(new { result = true, message = "Update User failed !" });
            }
        }

        [HttpDelete("delete-user")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete_User(string username)
        {
            try
            {

                var user = await userManager.FindByNameAsync(username);
                userManager.DeleteAsync(user);

                return Ok(new { result = true, message = "Delete User successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete User failed !" });
            }
        }

    }
}

namespace DocInfo.App.Controllers
{
    using DocInfo.App.Helpers;
    using DocInfo.App.Models.UserModels;
    using DocInfo.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly ApplicationSettings appSettings;

        public UserController(
            IUserService userService,
            IOptions<ApplicationSettings> appSettings)
        {
            this.userService = userService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<ActionResult> Regiser(RegisterRequestModel model)
        {
            var result = await this.userService.CreateUserAsync(model.UserName, model.Password, model.Email);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        //public async Task<ActionResult<string>> Login(LoginRequestModel model) 
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model) 
        {
            var userId = await this.userService.HaveUser(model.UserName);
            if (userId == string.Empty)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userService.CheckPassword(model.UserName, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var encriptedToken = JwtTolkenGenerator.GenerateToken(this.appSettings.Secret, userId, model.UserName);

            //return JsonSerializer.Serialize(encriptedToken);
            return new LoginResponseModel
            {
                Token = encriptedToken
            };
        }
    }
}

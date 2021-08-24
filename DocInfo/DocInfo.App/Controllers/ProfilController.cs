namespace DocInfo.App.Controllers
{
    using DocInfo.App.Models.ProfilModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilController : ApiController
    {
        [HttpPost]
        //[AllowAnonymous]
        [Route("create")]
        public IActionResult Create(CreateProfilModel model)
        {
            ;

            return Ok();
        }
    }
}

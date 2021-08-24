namespace DocInfo.App.Models.ProfilModels
{
    using Microsoft.AspNetCore.Http;
    using System;

    public class CreateProfilModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public IFormFile Image { get; set; }
    }
}

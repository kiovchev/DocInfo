namespace DocInfo.Data.Models
{
    using DocInfo.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        public Profile()
        {
            this.Documents = new HashSet<Document>();
            this.Publications = new HashSet<Publication>();
        }

        [Key]
        public int ProfileId { get; set; }

        [Required]
        [StringLength(maximumLength:GlobalConstants.ProfilFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstants.ProfilLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public byte[] ImageData { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public IEnumerable<Publication> Publications { get; set; }
    }
}

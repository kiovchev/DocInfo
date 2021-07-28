namespace DocInfo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        public Profile()
        {
            this.Documents = new HashSet<Document>();
        }

        [Key]
        public int ProfileId { get; set; }

        [Required]
        [StringLength(maximumLength:30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public byte[] ImageData { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Document> Documents { get; set; }
    }
}

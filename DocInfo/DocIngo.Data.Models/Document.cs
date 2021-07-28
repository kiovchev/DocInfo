namespace DocInfo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        [StringLength(maximumLength:50)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}

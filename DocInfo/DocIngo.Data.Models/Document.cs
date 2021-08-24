namespace DocInfo.Data.Models
{
    using DocInfo.Common;
    using System.ComponentModel.DataAnnotations;

    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        [StringLength(maximumLength:GlobalConstants.DocTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstants.DocDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}

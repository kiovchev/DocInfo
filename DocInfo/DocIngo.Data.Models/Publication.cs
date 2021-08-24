namespace DocInfo.Data.Models
{
    using DocInfo.Common;
    using System.ComponentModel.DataAnnotations;

    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }

        [Required]
        [StringLength(maximumLength:GlobalConstants.PublicationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength:GlobalConstants.PublicationContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}

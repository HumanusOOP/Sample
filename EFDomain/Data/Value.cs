using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDomain.Data
{
    public class Value
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        [Required]
        public bool Active { get; set; }

        public int? InquiryId { get; set; }

        [ForeignKey("InquiryId")]
        public virtual Inquiry Inquiry { get; set; }
    }

    public class Inquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string InquiryString { get; set; }
    }
}
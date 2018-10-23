using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NotesApi.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Note> Notes { get; set; }
    }

    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

namespace NoteManagement.Core.Models
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }

        public int? ParentNoteId { get; set; }
        public Note ParentNote { get; set; }

        public ICollection<Note>? SubNotes { get; set; } = new List<Note>();


    }
}

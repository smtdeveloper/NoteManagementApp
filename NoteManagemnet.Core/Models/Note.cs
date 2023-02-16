namespace NoteManagement.Core.Models
{
    public class Note : BaseEntity
    {
        public int? ParentNoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Note>? SubNotes { get; set; }

    }
}

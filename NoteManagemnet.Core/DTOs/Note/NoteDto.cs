namespace NoteManagement.Core.DTOs.Note
{
    public class NoteDto
    {
        public int Id { get; set; }
        public int? ParentNoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

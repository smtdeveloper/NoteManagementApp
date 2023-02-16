namespace NoteManagement.Core.DTOs.Note
{
    public class NoteUpdateDto
    {
        public int Id { get; set; }
        public int? ParentNoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using AutoMapper;
using NoteManagement.Core.DTOs.Note;
using NoteManagement.Core.Models;

namespace NoteManagement.Service.Mapping
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<Note, NoteUpdateDto>().ReverseMap();

        }
    }
}

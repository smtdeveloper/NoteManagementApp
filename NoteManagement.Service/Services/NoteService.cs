using NoteManagement.Core.Models;
using NoteManagement.Core.Repositories;
using NoteManagement.Core.Services;

namespace NoteManagement.Service.Services
{
    public class NoteService : GenericService<Note>, INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(IGenericRepository<Note> repository, INoteRepository noteRepository) : base(repository)
        {
            _noteRepository = noteRepository;
        }

    }
}

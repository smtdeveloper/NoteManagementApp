using NoteManagement.Core.Models;
using NoteManagement.Core.Repositories;

namespace NoteManagement.Repository.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context) : base(context)
        {
        }

    }
}

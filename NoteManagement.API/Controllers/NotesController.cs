using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteManagement.Core.DTOs;
using NoteManagement.Core.DTOs.GenericDTO;
using NoteManagement.Core.DTOs.Note;
using NoteManagement.Core.Models;
using NoteManagement.Core.Services;

namespace NoteManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Note> _noteService;

        public NotesController(IMapper mapper, IGenericService<Note> noteService)
        {
            _mapper = mapper;
            _noteService = noteService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteService.GetAllAsync();
            var noteDtos = _mapper.Map<List<NoteDto>>(notes).ToList();

            return CreateActionResult(CustomResponseDto<List<NoteDto>>.Success(200, noteDtos));

        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteService.GetByIdAsync(id);

            var noteDto = _mapper.Map<NoteDto>(note);
            return CreateActionResult(CustomResponseDto<NoteDto>.Success(200, noteDto));

        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(NoteDto noteDto)
        {
            var entity = _mapper.Map<Note>(noteDto);

            var note = await _noteService.AddAsync(entity);

            var newDto = _mapper.Map<NoteDto>(note);

            //return Ok(newDto);
            return CreateActionResult(CustomResponseDto<NoteDto>.Success(201, newDto));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(NoteUpdateDto noteUpdateDto)
        {
            var entity = _mapper.Map<Note>(noteUpdateDto);
            await _noteService.UpdateAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedNote = await _noteService.GetByIdAsync(id);
            await _noteService.RemoveAsync(deletedNote);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }


    }
}

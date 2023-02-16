using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagement.Core.Models;

namespace NoteManagement.Repository.Configurations.Seeds
{
    internal class NoteSeed : IEntityTypeConfiguration<Note>
    {
        //Seed Data 
        public void Configure(EntityTypeBuilder<Note> builder)
        {

            builder.HasData(
                new Note
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Title = "KodLab Yayınları",
                    Text = "KodLab Yayınların en iyi 3 kitapı",
                    IsDeleted = false,
                    ParentNoteId = null
                },
                new Note
                {
                    Id = 2,
                    ParentNoteId = 1,
                    CreatedDate = DateTime.Now,
                    Title = "KodLab C# Kitabı",
                    Text = "C# Kitap içeriği",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 3,
                    ParentNoteId = 2,
                    CreatedDate = DateTime.Now,
                    Title = "MVC",
                    Text = "Model View Controller",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 4,
                    ParentNoteId = 2,
                    CreatedDate = DateTime.Now,
                    Title = "CQRS",
                    Text = "Command-Query Separation",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 5,
                    ParentNoteId = 2,
                    CreatedDate = DateTime.Now,
                    Title = "Api",
                    Text = "Application Programming Interface",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 6,
                    ParentNoteId = 1,
                    CreatedDate = DateTime.Now,
                    Title = "KodLab Algoritma Kitabı",
                    Text = "Algoritma Kitap içeriği ",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 7,
                    ParentNoteId = 6,
                    CreatedDate = DateTime.Now,
                    Title = "Akış Diyagramları",
                    Text = "Nasıl Tasarlanır.",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 8,
                    ParentNoteId = 6,
                    CreatedDate = DateTime.Now,
                    Title = "Programlamaya giriş",
                    Text = "C++ ve java",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 9,
                    ParentNoteId = 1,
                    CreatedDate = DateTime.Now,
                    Title = "Kodlab Java Kitabı",
                    Text = "Java Kitap içeriği",
                    IsDeleted = false
                },
                new Note
                {
                    Id = 10,
                    ParentNoteId = 9,
                    CreatedDate = DateTime.Now,
                    Title = "Spring boot",
                    Text = "Spring boot kullanımı",
                    IsDeleted = false
                }
            );


        }
    }
}

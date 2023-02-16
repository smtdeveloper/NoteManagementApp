using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoteManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ParentNoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Notes_ParentNoteId",
                        column: x => x.ParentNoteId,
                        principalTable: "Notes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ParentNoteId", "Text", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7705), false, null, "KodLab Yayınların en iyi 3 kitapı", "KodLab Yayınları", null },
                    { 2, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7714), false, 1, "C# Kitap içeriği", "KodLab C# Kitabı", null },
                    { 6, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7718), false, 1, "Algoritma Kitap içeriği ", "KodLab Algoritma Kitabı", null },
                    { 9, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7721), false, 1, "Java Kitap içeriği", "Kodlab Java Kitabı", null },
                    { 3, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7715), false, 2, "Model View Controller", "MVC", null },
                    { 4, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7716), false, 2, "Command-Query Separation", "CQRS", null },
                    { 5, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7717), false, 2, "Application Programming Interface", "Api", null },
                    { 7, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7719), false, 6, "Nasıl Tasarlanır.", "Akış Diyagramları", null },
                    { 8, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7720), false, 6, "C++ ve java", "Programlamaya giriş", null },
                    { 10, new DateTime(2023, 2, 16, 19, 16, 57, 323, DateTimeKind.Local).AddTicks(7722), false, 9, "Spring boot kullanımı", "Spring boot", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParentNoteId",
                table: "Notes",
                column: "ParentNoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}

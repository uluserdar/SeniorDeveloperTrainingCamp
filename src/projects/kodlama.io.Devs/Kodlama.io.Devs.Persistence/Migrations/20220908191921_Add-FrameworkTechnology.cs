using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class AddFrameworkTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrameworkTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrameworkTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FrameworkTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "ASP.NET", 1 },
                    { 2, "WPF", 1 },
                    { 3, "Spring", 2 },
                    { 4, "JSP", 2 },
                    { 5, "Django", 3 },
                    { 6, "Laravel", 4 },
                    { 7, "CodeIgniter", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkTechnologies_ProgrammingLanguageId",
                table: "FrameworkTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrameworkTechnologies");
        }
    }
}

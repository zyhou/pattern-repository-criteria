using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessData.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    IdBlog = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.IdBlog);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    IdPoste = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    IdBlog = table.Column<int>(nullable: false),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.IdPoste);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_IdBlog",
                        column: x => x.IdBlog,
                        principalTable: "Blogs",
                        principalColumn: "IdBlog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdBlog",
                table: "Posts",
                column: "IdBlog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}

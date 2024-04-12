﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotoGalleryMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaRuolo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ruolo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ruolo",
                table: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShahanStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    BannerImg = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MetaTitle = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MetaDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IndexPage = table.Column<bool>(type: "boolean", nullable: false),
                    Canonical = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    OgTitle = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    OgDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    OgImage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Schema = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Slug",
                schema: "dbo",
                table: "Brands",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");
        }
    }
}

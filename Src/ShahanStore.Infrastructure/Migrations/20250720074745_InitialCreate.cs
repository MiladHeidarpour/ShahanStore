using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShahanStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    BannerImg = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OccurredOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProcessedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PossibleValues = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryAttribute_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                schema: "dbo",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                schema: "dbo",
                table: "Categories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_CategoryId",
                table: "CategoryAttribute",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAttribute");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShahanStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttribute_Categories_CategoryId",
                table: "CategoryAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute");

            migrationBuilder.EnsureSchema(
                name: "category");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                newName: "OutboxMessages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryAttribute",
                newName: "CategoryAttributes",
                newSchema: "category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttribute_CategoryId",
                schema: "category",
                table: "CategoryAttributes",
                newName: "IX_CategoryAttributes_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "category",
                table: "CategoryAttributes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttributes",
                schema: "category",
                table: "CategoryAttributes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessages_ProcessedOnUtc",
                schema: "dbo",
                table: "OutboxMessages",
                column: "ProcessedOnUtc");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributes_Categories_CategoryId",
                schema: "category",
                table: "CategoryAttributes",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributes_Categories_CategoryId",
                schema: "category",
                table: "CategoryAttributes");

            migrationBuilder.DropIndex(
                name: "IX_OutboxMessages_ProcessedOnUtc",
                schema: "dbo",
                table: "OutboxMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttributes",
                schema: "category",
                table: "CategoryAttributes");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "dbo",
                newName: "OutboxMessages");

            migrationBuilder.RenameTable(
                name: "CategoryAttributes",
                schema: "category",
                newName: "CategoryAttribute");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributes_CategoryId",
                table: "CategoryAttribute",
                newName: "IX_CategoryAttribute_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryAttribute",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttribute_Categories_CategoryId",
                table: "CategoryAttribute",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

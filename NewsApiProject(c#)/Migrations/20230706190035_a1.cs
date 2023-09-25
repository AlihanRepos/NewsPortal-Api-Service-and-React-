using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApiProject.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    NewsCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCategory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.NewsCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "NewsSource",
                columns: table => new
                {
                    NewsSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorpationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorpationPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSource", x => x.NewsSourceId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "NewsCast",
                columns: table => new
                {
                    NewsCastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultimediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NewsSourceId = table.Column<int>(type: "int", nullable: false),
                    NewsCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCast", x => x.NewsCastId);
                    table.ForeignKey(
                        name: "FK_NewsCast_NewsCategory_NewsCategoryId",
                        column: x => x.NewsCategoryId,
                        principalTable: "NewsCategory",
                        principalColumn: "NewsCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsCast_NewsSource_NewsSourceId",
                        column: x => x.NewsSourceId,
                        principalTable: "NewsSource",
                        principalColumn: "NewsSourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsSubscriber",
                columns: table => new
                {
                    NewsSubscriberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSubscriber = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NewsSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSubscriber", x => x.NewsSubscriberId);
                    table.ForeignKey(
                        name: "FK_NewsSubscriber_NewsSource_NewsSourceId",
                        column: x => x.NewsSourceId,
                        principalTable: "NewsSource",
                        principalColumn: "NewsSourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsSubscriber_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsComment",
                columns: table => new
                {
                    NewsCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NewsCastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsComment", x => x.NewsCommentId);
                    table.ForeignKey(
                        name: "FK_NewsComment_NewsCast_NewsCastId",
                        column: x => x.NewsCastId,
                        principalTable: "NewsCast",
                        principalColumn: "NewsCastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsFav",
                columns: table => new
                {
                    NewsFavId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fav = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NewsCastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFav", x => x.NewsFavId);
                    table.ForeignKey(
                        name: "FK_NewsFav_NewsCast_NewsCastId",
                        column: x => x.NewsCastId,
                        principalTable: "NewsCast",
                        principalColumn: "NewsCastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsFav_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsShare",
                columns: table => new
                {
                    NewsShareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SendUserId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NewsCastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsShare", x => x.NewsShareId);
                    table.ForeignKey(
                        name: "FK_NewsShare_NewsCast_NewsCastId",
                        column: x => x.NewsCastId,
                        principalTable: "NewsCast",
                        principalColumn: "NewsCastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsShare_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsCast_NewsCategoryId",
                table: "NewsCast",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCast_NewsSourceId",
                table: "NewsCast",
                column: "NewsSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment_NewsCastId",
                table: "NewsComment",
                column: "NewsCastId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment_UserId",
                table: "NewsComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFav_NewsCastId",
                table: "NewsFav",
                column: "NewsCastId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFav_UserId",
                table: "NewsFav",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsShare_NewsCastId",
                table: "NewsShare",
                column: "NewsCastId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsShare_UserId",
                table: "NewsShare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsSubscriber_NewsSourceId",
                table: "NewsSubscriber",
                column: "NewsSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsSubscriber_UserId",
                table: "NewsSubscriber",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsComment");

            migrationBuilder.DropTable(
                name: "NewsFav");

            migrationBuilder.DropTable(
                name: "NewsShare");

            migrationBuilder.DropTable(
                name: "NewsSubscriber");

            migrationBuilder.DropTable(
                name: "NewsCast");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropTable(
                name: "NewsSource");
        }
    }
}

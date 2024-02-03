﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RoleTypes",
                columns: table => new
                {
                    RoleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleNameLowered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsListed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTypes", x => x.RoleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserActionTypes",
                columns: table => new
                {
                    UserActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionTypes", x => x.UserActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordResetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WrongPasswordCount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BioText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowerCount = table.Column<int>(type: "int", nullable: false),
                    FollowingCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_RoleTypes_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleTypes",
                        principalColumn: "RoleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleActionTypes",
                columns: table => new
                {
                    RoleActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActionTypes", x => x.RoleActionTypeId);
                    table.ForeignKey(
                        name: "FK_RoleActionTypes_RoleTypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "RoleTypes",
                        principalColumn: "RoleTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActionTypes_UserActionTypes_UserActionTypeId",
                        column: x => x.UserActionTypeId,
                        principalTable: "UserActionTypes",
                        principalColumn: "UserActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "Id", "FollowerId", "FollowingId" },
                values: new object[,]
                {
                    { 1, new Guid("3db611ca-9ede-4497-b256-b83edd51b647"), new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f") },
                    { 2, new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"), new Guid("3db611ca-9ede-4497-b256-b83edd51b647") }
                });

            migrationBuilder.InsertData(
                table: "RoleTypes",
                columns: new[] { "RoleTypeId", "IsListed", "RoleName", "RoleNameLowered" },
                values: new object[] { new Guid("567ceb59-3058-40ed-8999-f095202939c8"), true, "User", "user" });

            migrationBuilder.InsertData(
                table: "UserActionTypes",
                columns: new[] { "UserActionTypeId", "ActionCategory", "ActionName", "Type" },
                values: new object[] { 1, "dashboard", "Anasayfa", "Dashboard" });

            migrationBuilder.InsertData(
                table: "RoleActionTypes",
                columns: new[] { "RoleActionTypeId", "RoleTypeId", "UserActionTypeId" },
                values: new object[] { 1, new Guid("567ceb59-3058-40ed-8999-f095202939c8"), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[] { new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"), null, new Guid("00000000-0000-0000-0000-000000000000"), "test@test", 1, 1, true, false, false, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9710), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Shft", "test@test", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[] { new Guid("3db611ca-9ede-4497-b256-b83edd51b647"), null, new Guid("00000000-0000-0000-0000-000000000000"), "i.yigittin@hotmail.com", 1, 1, true, false, false, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbrahim Yiğit", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9702), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Tın", "i.yigittin@hotmail.com", 0 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 1, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9724), "seeder", false, 0, "seeder", new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9726), "SHFTGRAM IS ONLINE", new Guid("3db611ca-9ede-4497-b256-b83edd51b647") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 2, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9727), "seeder", false, 0, "seeder", new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9728), "FEEL FREE TO EXPLORE", new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f") });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActionTypes_RoleTypeId",
                table: "RoleActionTypes",
                column: "RoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActionTypes_UserActionTypeId",
                table: "RoleActionTypes",
                column: "UserActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "RoleActionTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserActionTypes");

            migrationBuilder.DropTable(
                name: "RoleTypes");
        }
    }
}

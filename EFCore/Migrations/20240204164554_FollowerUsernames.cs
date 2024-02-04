using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class FollowerUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb"));

            migrationBuilder.AddColumn<string>(
                name: "FollowerUserName",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FollowingUserName",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FollowerId", "FollowerUserName", "FollowingId", "FollowingUserName" },
                values: new object[] { new Guid("551b9b2d-dacb-4603-b3cc-405ba09b8210"), "i.yigittin@hotmail.com", new Guid("c6a46743-146b-469e-ad3f-26b74b80e6c0"), "test@test" });

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FollowerId", "FollowerUserName", "FollowingId", "FollowingUserName" },
                values: new object[] { new Guid("c6a46743-146b-469e-ad3f-26b74b80e6c0"), "test@test", new Guid("551b9b2d-dacb-4603-b3cc-405ba09b8210"), "i.yigittin@hotmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[,]
                {
                    { new Guid("551b9b2d-dacb-4603-b3cc-405ba09b8210"), "BIO TEXT", new Guid("00000000-0000-0000-0000-000000000000"), "i.yigittin@hotmail.com", 1, 1, true, false, false, new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5692), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbrahim Yiğit", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5700), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Tın", "i.yigittin@hotmail.com", 0 },
                    { new Guid("c6a46743-146b-469e-ad3f-26b74b80e6c0"), "BIO TEXT", new Guid("00000000-0000-0000-0000-000000000000"), "test@test", 1, 1, true, false, false, new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5703), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Shft", "test@test", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5721), new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5722), new Guid("551b9b2d-dacb-4603-b3cc-405ba09b8210") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 2, 4, 19, 45, 54, 261, DateTimeKind.Local).AddTicks(5724), new Guid("c6a46743-146b-469e-ad3f-26b74b80e6c0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("551b9b2d-dacb-4603-b3cc-405ba09b8210"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c6a46743-146b-469e-ad3f-26b74b80e6c0"));

            migrationBuilder.DropColumn(
                name: "FollowerUserName",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "FollowingUserName",
                table: "Follows");

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb"), new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab") });

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab"), new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[,]
                {
                    { new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab"), null, new Guid("00000000-0000-0000-0000-000000000000"), "test@test", 1, 1, true, false, false, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3016), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3017), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Shft", "test@test", 0 },
                    { new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb"), null, new Guid("00000000-0000-0000-0000-000000000000"), "i.yigittin@hotmail.com", 1, 1, true, false, false, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbrahim Yiğit", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3013), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Tın", "i.yigittin@hotmail.com", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3034), new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3035), new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3037), new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab") });
        }
    }
}

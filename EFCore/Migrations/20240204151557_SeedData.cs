using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("5b302cb7-8011-4484-ba21-f187eb582f61"));

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

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 3, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3034), "seeder", false, 0, "seeder", new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3035), "SHFTGRAM IS ONLINE", new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 4, new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3036), "seeder", false, 0, "seeder", new DateTime(2024, 2, 4, 18, 15, 57, 577, DateTimeKind.Local).AddTicks(3037), "FEEL FREE TO EXPLORE", new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("23ae2075-17cb-4bd8-ac76-5e9a889c84ab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ed84e5e2-e41d-48cf-adb9-6d267dd0feeb"));

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2"), new Guid("5b302cb7-8011-4484-ba21-f187eb582f61") });

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("5b302cb7-8011-4484-ba21-f187eb582f61"), new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[,]
                {
                    { new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2"), null, new Guid("00000000-0000-0000-0000-000000000000"), "i.yigittin@hotmail.com", 1, 1, true, false, false, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5826), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbrahim Yiğit", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5836), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Tın", "i.yigittin@hotmail.com", 0 },
                    { new Guid("5b302cb7-8011-4484-ba21-f187eb582f61"), null, new Guid("00000000-0000-0000-0000-000000000000"), "test@test", 1, 1, true, false, false, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5838), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5839), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Shft", "test@test", 0 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 1, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5943), "seeder", false, 0, "seeder", new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5944), "SHFTGRAM IS ONLINE", new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "IsDeleted", "LikeCount", "ModifiedBy", "ModifiedTime", "Text", "UserId" },
                values: new object[] { 2, new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5945), "seeder", false, 0, "seeder", new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5946), "FEEL FREE TO EXPLORE", new Guid("5b302cb7-8011-4484-ba21-f187eb582f61") });
        }
    }
}

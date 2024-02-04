using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class LikeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3db611ca-9ede-4497-b256-b83edd51b647"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5943), new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5944), new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5945), new DateTime(2024, 2, 4, 18, 12, 59, 883, DateTimeKind.Local).AddTicks(5946), new Guid("5b302cb7-8011-4484-ba21-f187eb582f61") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3bf99286-974e-432f-9bcb-af4a34ff42d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("5b302cb7-8011-4484-ba21-f187eb582f61"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("3db611ca-9ede-4497-b256-b83edd51b647"), new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f") });

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[] { new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"), new Guid("3db611ca-9ede-4497-b256-b83edd51b647") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BioText", "ConfirmationGuid", "Email", "FollowerCount", "FollowingCount", "IsConfirmed", "IsDeleted", "IsLocked", "LastActivateDate", "LastLogin", "LastPasswordResetDate", "Name", "Password", "Phone", "ProfilePicture", "RegisterDate", "RoleId", "Surname", "UserName", "WrongPasswordCount" },
                values: new object[,]
                {
                    { new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"), null, new Guid("00000000-0000-0000-0000-000000000000"), "test@test", 1, 1, true, false, false, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9710), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Shft", "test@test", 0 },
                    { new Guid("3db611ca-9ede-4497-b256-b83edd51b647"), null, new Guid("00000000-0000-0000-0000-000000000000"), "i.yigittin@hotmail.com", 1, 1, true, false, false, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbrahim Yiğit", "+XLIphBpHWTKXJL0co5lySTbhS0=", "5395954339", null, new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9702), new Guid("567ceb59-3058-40ed-8999-f095202939c8"), "Tın", "i.yigittin@hotmail.com", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9724), new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9726), new Guid("3db611ca-9ede-4497-b256-b83edd51b647") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifiedTime", "UserId" },
                values: new object[] { new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9727), new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9728), new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f") });
        }
    }
}

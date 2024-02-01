using EFCore.DbModels;
using SHFTGRAMAPP.EFCore.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    //dotnet ef migrations add InitialMigration -s ..\SHFTGRAM\SHFTGRAM.csproj
    //dotnet ef database update -s..\SHFTGRAM\SHFTGRAM.csproj
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RoleActionType> RoleActionTypes { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<UserActionType> UserActionTypes { get; set; }
        public DbSet<UploadedFiles> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleType>().HasData(
                new RoleType()
                {
                    IsListed = true,
                    RoleName = "User",
                    RoleNameLowered = "user",
                    RoleTypeId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8")
                });
            modelBuilder.Entity<UserActionType>().HasData(
                new UserActionType()
                {
                    UserActionTypeId = 1,
                    ActionCategory = "dashboard",
                    ActionName = "Anasayfa",
                    Type = "Dashboard"
                });
            modelBuilder.Entity<RoleActionType>().HasData(
                new RoleActionType()
                {
                    RoleActionTypeId = 1,
                    RoleTypeId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8"),
                    UserActionTypeId = 1
                });
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = Guid.NewGuid(),
                    Email = "i.yigittin@hotmail.com",
                    IsConfirmed = true,
                    IsDeleted = false,
                    IsLocked = false,
                    LastActivateDate = DateTime.Now,
                    LastLogin = DateTime.MinValue,
                    LastPasswordResetDate = DateTime.MinValue,
                    Name = "İbrahim Yiğit",
                    Password = "+XLIphBpHWTKXJL0co5lySTbhS0=",
                    Phone = "5395954339",
                    RegisterDate = DateTime.Now,
                    RoleId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8"),
                    Surname = "Tın",
                    UserName = "i.yigittin@hotmail.com",
                    WrongPasswordCount = 0,
                    PointAverage = 0,
                    PointCount = 0,
                    TotalPoint = 0
                });
        }
    }
}
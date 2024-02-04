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
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Likes> Likes{ get; set; }
        public DbSet<Follow> Follows{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customUser1 = Guid.NewGuid();
            var customUser2 = Guid.NewGuid();


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
                    UserId = customUser1,
                    Email = "i.yigittin@hotmail.com",
                    IsConfirmed = true,
                    IsDeleted = false,
                    IsLocked = false,
                    LastActivateDate = DateTime.Now,
                    LastLogin = DateTime.MinValue,
                    LastPasswordResetDate = DateTime.MinValue,
                    Name = "İbrahim Yiğit",
                    BioText = "BIO TEXT",
                    Password = "+XLIphBpHWTKXJL0co5lySTbhS0=",
                    Phone = "5395954339",
                    RegisterDate = DateTime.Now,
                    RoleId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8"),
                    Surname = "Tın",
                    UserName = "i.yigittin@hotmail.com",
                    WrongPasswordCount = 0,
                    FollowerCount=1,
                    FollowingCount=1

                },
                new User()
                {
                    UserId = customUser2,
                    Email = "test@test",
                    IsConfirmed = true,
                    IsDeleted = false,
                    IsLocked = false,
                    LastActivateDate = DateTime.Now,
                    LastLogin = DateTime.MinValue,
                    LastPasswordResetDate = DateTime.MinValue,
                    Name = "Test User",
                    BioText = "BIO TEXT",
                    Password = "+XLIphBpHWTKXJL0co5lySTbhS0=",
                    Phone = "5395954339",
                    RegisterDate = DateTime.Now,
                    RoleId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8"),
                    Surname = "Shft",
                    UserName = "test@test",
                    WrongPasswordCount = 0,
                    FollowerCount = 1,
                    FollowingCount = 1
                });
            modelBuilder.Entity<Follow>().HasData(
                new Follow()
                {
                    Id=1,
                    FollowerId=customUser1,
                    FollowerUserName= "i.yigittin@hotmail.com",
                    FollowingId =customUser2,
                    FollowingUserName= "test@test"
                },
                new Follow()
                {
                    Id=2,
                    FollowerId = customUser2,
                    FollowerUserName = "test@test",
                    FollowingId = customUser1,
                    FollowingUserName = "i.yigittin@hotmail.com"
                });
            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    CreatedBy="seeder",
                    CreateTime=DateTime.Now,
                    Id=3,
                    IsDeleted=false,
                    LikeCount=0,
                    ModifiedBy="seeder",
                    ModifiedTime=DateTime.Now,
                    Text="SHFTGRAM IS ONLINE",
                    UserId=customUser1
                },
                new Post()
                {
                    CreatedBy = "seeder",
                    CreateTime = DateTime.Now,
                    Id = 4,
                    IsDeleted = false,
                    LikeCount = 0,
                    ModifiedBy = "seeder",
                    ModifiedTime = DateTime.Now,
                    Text = "FEEL FREE TO EXPLORE",
                    UserId = customUser2
                });
        }
    }
}
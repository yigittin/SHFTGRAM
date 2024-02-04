using AutoMapper;
using Core.User;
using EFCore.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Service.Login;
using Service.Post;
using Service.User;
using SHFTGRAM.ViewModels;
using SHFTGRAM.ViewModels.PostView;
using SHFTGRAM.ViewModels.UserView;
using SHFTGRAMAPP.Core.Exceptions;
using SHFTGRAMAPP.ViewModels.User;
using System.IdentityModel.Tokens.Jwt;

namespace SHFTGRAM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configs;
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public UserController(IConfiguration configs, ILoginService loginService, IMapper mapper, IUserService userService, IPostService postService)
        {
            _configs = configs;
            _loginService = loginService;
            _mapper = mapper;
            _userService = userService;
            _postService = postService;
        }
        [HttpPost("UpdateProfile")]
        public async Task<ActionResult<BaseResult<UserDto>>> UpdateUser(UpdateUserDto input)
        {
            try
            {
                var userService = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var updateUser = _mapper.Map<UpdateUser>(input);
                var userId = userService.GetUserId();
                var newUser = _mapper.Map<UserPageDto>(await _userService.UpdateProfile(updateUser,userId));
                return Ok(new BaseResult<UserPageDto>("Update Completed", newUser));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message,false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
        [HttpPost("Follow")]
        public async Task<ActionResult<ResponseResult>> FollowUser([FromBody]Guid id)
        {
            try
            {
                var userService = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userService.GetUserId();
                await _userService.Follow(userId, id);
                return Ok(new ResponseResult("Followed", true));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
        [HttpPost("Unfollow")]
        public async Task<ActionResult<ResponseResult>> UnfollowUser(Guid id)
        {
            try
            {
                var userService = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userService.GetUserId();
                await _userService.UnFollow(userId, id);
                return Ok(new ResponseResult("Unfollowed", true));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
        [HttpGet("GetUserPage")]
        public async Task<ActionResult<BaseResult<UserDto>>> GetUserPage(Guid? id)
        {            
            try
            {
                if(id is null)
                {
                    var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                    var userId = userManager.GetUserId();
                    var username = userManager.GetUserName();
                    var userInfo=_mapper.Map<UserDto>(await _userService.GetUserPage(userId));
                    var posts = new List<PostDto>();
                    var postData = await _postService.GetUserPosts(userId);
                    foreach(var item in postData)
                    {
                        var singlePost = _mapper.Map<PostDto>(item);
                        singlePost.UserName = username;
                        posts.Add(singlePost);  
                    }
                    userInfo.Posts = posts;
                    return Ok(new BaseResult<UserDto>("User information success",userInfo));
                }
                else
                {
                    var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                    var userId = userManager.GetUserId();
                    var username = userManager.GetUserName();
                    var userInfo = _mapper.Map<UserDto>(await _userService.GetUserPage((Guid)id));
                    var posts = new List<PostDto>();
                    var postData = await _postService.GetUserPosts((Guid)id);
                    foreach (var item in postData)
                    {
                        var singlePost = _mapper.Map<PostDto>(item);
                        singlePost.UserName = userInfo.UserName;
                        posts.Add(singlePost);
                    }
                    userInfo.Posts = posts;
                    userInfo.IsFollowed = await _userService.CheckFollow((Guid)id, userId);
                    return Ok(new BaseResult<UserDto>("User information success", userInfo));
                }
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
        [HttpGet("SearchUser")]
        public async Task<ActionResult<BaseResult<List<UserDto>>>> SearchUser(string search)
        {
            try
            {
                var searchedList = new List<UserDto>();
                var data= await _userService.SearchUsers(search);
                foreach (var item in data)
                {
                    searchedList.Add(_mapper.Map<UserDto>(item));   
                }
                return Ok(new BaseResult<List<UserDto>>("Search completed", searchedList));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Search failed : " + ex.Message, false));
            }
        }
        [HttpGet("GetFollowers")]
        public async Task<ActionResult<BaseResult<List<FollowDto>>>> GetFollowers(Guid? id)
        {
            try
            {
                if (id is null)
                {
                    var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                    var userId = userManager.GetUserId();
                    var followers = await _userService.GetFollowers(userId);
                    var followersList = new List<FollowDto>();  
                    foreach(var item in followers)
                    {
                        followersList.Add(_mapper.Map<FollowDto>(item));
                    }
                    return Ok(new BaseResult<List<FollowDto>>("User information success", followersList));
                }
                else if(id is not null)
                {
                    var followers = await _userService.GetFollowers((Guid)id);
                    var followersList = new List<FollowDto>();
                    foreach (var item in followers)
                    {
                        followersList.Add(_mapper.Map<FollowDto>(item));
                    }
                    return Ok(new BaseResult<List<FollowDto>>("User information success", followersList));
                }
                else
                {
                    return BadRequest(new ResponseResult("No Id Gathered",false));
                }
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
        [HttpGet("GetFollowings")]
        public async Task<ActionResult<BaseResult<List<FollowDto>>>> GetFollows(Guid? id)
        {
            try
            {
                if (id is null)
                {
                    var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                    var userId = userManager.GetUserId();
                    var followers = await _userService.GetFollowing(userId);
                    var followersList = new List<FollowDto>();
                    foreach (var item in followers)
                    {
                        followersList.Add(_mapper.Map<FollowDto>(item));
                    }
                    return Ok(new BaseResult<List<FollowDto>>("User information success", followersList));
                }
                else if (id is not null)
                {
                    var followers = await _userService.GetFollowing((Guid)id);
                    var followersList = new List<FollowDto>();
                    foreach (var item in followers)
                    {
                        followersList.Add(_mapper.Map<FollowDto>(item));
                    }
                    return Ok(new BaseResult<List<FollowDto>>("User information success", followersList));
                }
                else
                {
                    return BadRequest(new ResponseResult("No Id Gathered", false));
                }
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult("Update failed : " + ex.Message, false));
            }
        }
    }
}

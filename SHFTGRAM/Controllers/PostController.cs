using AutoMapper;
using EFCore.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Login;
using Service.Post;
using Service.User;
using SHFTGRAM.ViewModels;
using SHFTGRAM.ViewModels.PostView;
using SHFTGRAMAPP.Core.Exceptions;

namespace SHFTGRAM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IConfiguration _configs;
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IConfiguration configs, ILoginService loginService, IUserService userService, IMapper mapper, IPostService postService)
        {
            _configs = configs;
            _loginService = loginService;
            _userService = userService;
            _mapper = mapper;
            _postService = postService;
        }
        [HttpGet("GetPostDetails")]
        public async Task<ActionResult<BaseResult<PostDto>>> GetPostDetails(int id)
        {
            try
            {
                var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userManager.GetUserId();
                var userName = userManager.GetUserName();
                var post = _mapper.Map<PostDto>(await _postService.GetSinglePost(id));
                post.UserName = userName;
                return Ok(new BaseResult<PostDto>("Post data success", post));
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

        //KULLANICININ SON PAYLAŞTIĞINI İLK POST OLARAK ALIR
        //TAKİP ETTİĞİ KULLANICILARIN SON 5 POSTUNU LİSTEYE ALIR
        //KULLANCININ SON PAYLAŞIMINDAN SONRAKİ 5 PAYLAŞIMI LİSTENİN SONUNA EKLER
        [HttpGet("GetHomePage")]
        public async Task<ActionResult<BaseResult<List<PostDto>>>> GetHomePage()
        {
            try
            {
                var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userManager.GetUserId();
                var userName = userManager.GetUserName();
                var posts = new List<PostDto>();
                var postData = await _postService.GetDashboardForUser(userId);
                foreach (var item in postData)
                {
                    var singlePost = _mapper.Map<PostDto>(item);
                    singlePost.UserName = await _userService.GetUserName(singlePost.UserId);
                    posts.Add(singlePost);
                }
                return Ok(new BaseResult<List<PostDto>>("Post data success", posts));
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
        [HttpDelete("PostDelete")]
        public async Task<ActionResult<ResponseResult>> DeletePost(int id)
        {
            try
            {
                var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userManager.GetUserId();
                await _postService.DeletePost(id,userId);
                return Ok(new ResponseResult("Delete success",true));
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
        //GELEN ID 0 OLMASI DURUMUNDA YENİ POST OLUŞTURUR
        //ID GEÇERLİ BİR POST ID İSE BUNU DÜZENLER
        [HttpPost("AddOrUpdatePost")]
        public async Task<ActionResult<BaseResult<PostDto>>> AddOrUpdatePost(AddOrUpdatePostDto input)
        {
            try
            {
                if (input.Id is null)
                    input.Id = 0;
                var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var res = await _postService.AddOrUpdatePost(_mapper.Map<Post>(input), userManager.GetUserId());
                return Ok(new BaseResult<PostDto>("Update Success",_mapper.Map<PostDto>(res)));
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
        [HttpPost("LikePost")]
        public async Task<ActionResult<ResponseResult>> LikePost([FromBody] int id)
        {
            try
            {
                var userManager = new UserManager.UserManager(HttpContext, _configs, _loginService);
                var userId = userManager.GetUserId();
                await _postService.LikePost(id, userId);
                return Ok(new ResponseResult("Like success", true));
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
                return BadRequest(new ResponseResult("Like failed : " + ex.Message, false));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Models;
using BLL.Services.InterfacesServices;
using DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UIL.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [ResponseCache(CacheProfileName = "120SecondsDuration")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class PostsController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public PostsController(IRepositoryManager context, IMapper mapper, ILoggerManager logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _context.Posts.GetAllPostsAsync(trackChanges: false);

            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return Ok(postsDto);
        }

        [HttpGet("{id}", Name = "PostById")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _context.Posts.GetPostAsync(id, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var postDto = _mapper.Map<PostDto>(post);
                return Ok(postDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
        {
            if (post == null)
            {
               _logger.LogError("PostForCreationDto object sent from client is null.");
                return BadRequest("PostForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                 _logger.LogError("Invalid model state for the PostForCreationDto object");
                 return UnprocessableEntity(ModelState);
            }

            var postEntity = _mapper.Map<Post>(post);
           
            _context.Posts.CreatePost(postEntity);
            await _context.SaveAsync();
           
            var postToReturn = _mapper.Map<PostDto>(postEntity);

            return CreatedAtRoute("PostById", new { id = postToReturn.Id },
           postToReturn);
        }

        [HttpGet("collection/({ids})", Name = "PostCollection")]
        public async Task<IActionResult> GetPostCollection(IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                 _logger.LogError("Parameter ids is null");
                 return BadRequest("Parameter ids is null");
            }
            var postEntities = await _context.Posts.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != postEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);

            return Ok(postsToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreatePostCollection([FromBody] IEnumerable<PostForCreationDto> postCollection)
        {
            if (postCollection == null)
            {
                _logger.LogError("Post collection sent from client is null.");
                return BadRequest("Post collection is null");
            }

            var postEntities = _mapper.Map<IEnumerable<Post>>(postCollection);

            foreach (var post in postEntities)
            {
                _context.Posts.CreatePost(post);
            }

            await _context.SaveAsync();

            var postCollectionToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);
            var ids = string.Join(",", postCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("PostCollection", new { ids }, postCollectionToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostForUpdateDto post)
        {
            if (post == null)
            {
                _logger.LogError("PostForUpdateDto object sent from client is null.");
                return BadRequest("PostForUpdateDto object is null");
            }

            var postEntity = await _context.Posts.GetPostAsync(id, trackChanges: true);
            if (postEntity == null)
            {
                _logger.LogInfo($"Post with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(post, postEntity);
            await _context.SaveAsync();

            return NoContent();
        }
    }
}

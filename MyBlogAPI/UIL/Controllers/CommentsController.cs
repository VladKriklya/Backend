using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Models;
using BLL.Services.InterfacesServices;
using DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UIL.Controllers
{
    [Route("api/posts/{postId}/comments")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CommentsController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CommentsController(IRepositoryManager context, IMapper mapper, ILoggerManager logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsForPost(Guid postId)
        {
            var post = await _context.Posts.GetPostAsync(postId, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {postId} doesn't exist in the database.");
                 return NotFound();
            }

            var commentsFromDb = await _context.Comments.GetCommentsAsync(postId, trackChanges: false);

            var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commentsFromDb);

            return Ok(commentsDto);
        }

        [HttpGet("{id}", Name = "GetCommentForPost")]
        public async Task<IActionResult> GetCommentForPost(Guid postId, Guid id)
        {
            var post = await _context.Posts.GetPostAsync(postId, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {postId} doesn't exist in the database.");
                 return NotFound();
            }
            
            var commentDb = await _context.Comments.GetCommentAsync(postId, id, trackChanges: false);
            if (commentDb == null)
            {
                _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var comment = _mapper.Map<CommentDto>(commentDb);

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentForPost(Guid postId, [FromBody] CommentForCreationDto comment)
        {
            if (comment == null)
            {
                _logger.LogError("CommentForCreationDto object sent from client is null.");
                return BadRequest("CommentForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CommentForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var post = await _context.Posts.GetPostAsync(postId, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {postId} doesn't exist in the database.");
                 return NotFound();
            }

            var commentEntity = _mapper.Map<Comment>(comment);

            _context.Comments.CreateCommentForPost(postId, commentEntity);
            await _context.SaveAsync();
        
            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return CreatedAtRoute("GetCommentForPost", new
            {
                postId,
                id = commentToReturn.Id
            }, commentToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentForPost(Guid postId, Guid id)
        {
            var post = await _context.Posts.GetPostAsync(postId, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {postId} doesn't exist in the database.");
                return NotFound();
            }

            var commentForPost = await _context.Comments.GetCommentAsync(postId, id, trackChanges: false);
            if (commentForPost == null)
            {
                _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _context.Comments.DeleteComment(commentForPost);
            await _context.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentForPost(Guid postId, Guid id, [FromBody] CommentForUpdateDto comment)
        {
            if (comment == null)
            {
                _logger.LogError("CommentForUpdateDto object sent from client is null.");
                return BadRequest("CommentForUpdateDto object is null");
            }

            var post = await _context.Posts.GetPostAsync(postId, trackChanges: false);
            if (post == null)
            {
                _logger.LogInfo($"Post with id: {postId} doesn't exist in the database.");
                return NotFound();
            }

            var commentEntity = await _context.Comments.GetCommentAsync(postId, id, trackChanges: true);
            if (commentEntity == null)
            {
               _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(comment, commentEntity);
            await _context.SaveAsync();

            return NoContent();
        }



    }
}

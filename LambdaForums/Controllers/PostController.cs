using System;
using System.Collections.Generic;
using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.PostViewModels;
using LambdaForums.Models.ReplyViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(x => new PostReplyModel
            {
                Id = x.Id,
                AuthorName = x.User.UserName,
                AuthorId = x.User.Id,
                AuthorImageUrl = x.User.ProfileImageUrl,
                AuthorRating = x.User.Rating,
                Created = x.Created,
                ReplyContent = x.Content
            });
        }
    }
}
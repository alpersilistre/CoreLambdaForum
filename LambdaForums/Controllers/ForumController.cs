﻿using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.ForumViewModels;
using LambdaForums.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LambdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll().Select(x => new ForumListingModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            });

            var indexModel = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(indexModel);
        }

        public IActionResult Forum(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(x => new PostListingModel
            {
                Id = x.Id,
                AuthorId = x.User.Id,
                AuthorRating = x.User.Rating,
                Title = x.Title,
                DatePosted = x.Created.ToString(),
                RepliesCount = x.Replies.Count(),
                Forum = BuildForumListing(x)
            });

            return View();
        }

        private ForumListingModel BuildForumListing(Post x)
        {
            throw new NotImplementedException();
        }
    }
}
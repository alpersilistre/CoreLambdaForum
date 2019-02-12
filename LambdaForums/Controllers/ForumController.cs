using LambdaForums.Data;
using LambdaForums.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
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

            var post = _postService.GetFilteredPosts(id);
        }
    }
}
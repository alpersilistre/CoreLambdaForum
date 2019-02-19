using LambdaForums.Models.PostViewModels;
using System.Collections.Generic;

namespace LambdaForums.Models.ForumViewModels
{
    public class ForumTopicViewModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}

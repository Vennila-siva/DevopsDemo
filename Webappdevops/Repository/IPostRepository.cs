using Webappdevops.Models;

namespace Webappdevops.Repository
{
    public interface IPostRepository
    {
        List<PostViewModel> GetPosts();
    }
}

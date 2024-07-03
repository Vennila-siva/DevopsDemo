using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webappdevops.Controllers;
using Webappdevops.Models;
using Webappdevops.Repository;

namespace Webappdevops.Test
{
    public class PostTestController
    {
        private IPostRepository repository;
        HomeController homeController;
        public PostTestController()
        {
            //logger = _logger;
            repository = new PostRepository();
            homeController = new HomeController(repository);
            //repository = new PostRepository();
        }
        [Fact]
        public void Test_Index_View_Result()
        {
            //Arrange
            var controller = homeController;
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Test_Index_Return_Result()
        {
            //Arrange
            var controller = homeController;
            //Act
            var result = controller.Index();
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Index_GetPosts_MatchData()
        {
            //Arrange
            var controller = homeController;
            //Act
            var result = controller.Index();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
            Assert.Equal(101, model[0].PostId);
            Assert.Equal("DevOps Demo Title 1", model[0].Title);
        }
    }
}
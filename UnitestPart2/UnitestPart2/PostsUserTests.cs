using Moq;
using PostAPI;
using System.Net.Sockets;
using Xunit;

namespace UnitestPart2
{    
    public class PostsUserTests
    {
        private readonly IPostsUserRepistory _postsUserRepistory;
        private readonly Mock<IPostsUserRepistory> _postsUserRepistoryMock;
        private readonly PostUser postUser;
        public PostsUserTests()
        {
            _postsUserRepistoryMock = new Mock<IPostsUserRepistory>();            
            //MockData with post with Id = 1
            postUser = new PostUser
            {
                UserId = 1,
                Id = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto"
            };

          _postsUserRepistoryMock.Setup(x => x.GetPostById(1))
                .Returns(Task.FromResult(postUser));

            _postsUserRepistory = _postsUserRepistoryMock.Object;
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldReturnPostWhenIdValid(int id)
        {
            var postUserActual = await _postsUserRepistory.GetPostById(id);

            Assert.Equal(postUser, postUserActual);
        }

    }
}
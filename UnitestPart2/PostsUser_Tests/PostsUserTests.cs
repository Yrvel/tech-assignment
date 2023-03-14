using Moq;
using PostAPI;

namespace UnitestPart2
{
    public class PostsUserTests
    {
        private readonly IPostsUserRepistory _postsUserRepistory;
        private readonly Mock<IPostsUserRepistory> _postsUserRepistoryMock;

        private readonly PostUser postUser;

        public PostsUserTests()
        {
            postUser = GetPostUserWithIdOne();

            _postsUserRepistoryMock = new Mock<IPostsUserRepistory>();

            _postsUserRepistoryMock.Setup(x => x.GetPostById(1))
                  .Returns(Task.FromResult(postUser));

            _postsUserRepistoryMock.Setup(x => x.GetPostsByUserId(1))
                  .Returns(Task.FromResult(GetPostsWithUserIdOne()));

            _postsUserRepistoryMock.Setup(x => x.GetPostById(101))
                 .Returns(Task.FromResult((PostUser)null));

            _postsUserRepistoryMock.Setup(x => x.GetPostsByUserId(11))
                 .Returns(Task.FromResult((List<PostUser>)null));

            _postsUserRepistory = _postsUserRepistoryMock.Object;
        }

        #region PositiveScenarios
        //The PostId must be between 1 and 10= to be valid
        [Theory]
        [InlineData(1)]
        public async Task ShouldReturnAPost_WhenIdValid(int id)
        {
            var postUserActual = await _postsUserRepistory.GetPostById(id);

            Assert.Equal(postUser, postUserActual);
        }

        //The UserId must be between 1 and 10 to be valid
        [Theory]
        [InlineData(1)]
        public async Task ShouldReturnAListPosts_WhenUserIdValid(int id)
        {
            var postsUserActual = await _postsUserRepistory.GetPostsByUserId(id);

            Assert.Equivalent(GetPostsWithUserIdOne(), postsUserActual, false);
        }

        #endregion

        #region NegativeScenarios
        //The Post Id must be specified and less or equal than 100
        [Theory]
        [InlineData(101)]
        [InlineData(null)]
        public async Task ShouldReturNull_WhenPostIdInvalid(int id)
        {
            var postUserActual = await _postsUserRepistory.GetPostById(id);

            Assert.Null(postUserActual);
        }

        //The User Id must be specified and less or equal than 100
        [Theory]
        [InlineData(11)]
        [InlineData(null)]
        public async Task ShouldReturNull_WhenPostUserIdInvalid(int id)
        {
            var postsUserActual = await _postsUserRepistory.GetPostsByUserId(id);

            Assert.Null(postsUserActual);
        }

        //The title and the body must be specified
        [Theory]
        [InlineData(1, "", "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto")]
        [InlineData(1, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", "")]
        public async Task ShoulNotReturnPost_WhenTitleOrBodyPostNotSpecified(int id, string title, string body)
        {
            var postUserActual = await _postsUserRepistory.GetPostById(id);
            var expectedPostUser = new PostUser
            {
                UserId = postUserActual.Id,
                Title = title,
                Body = body,
                Id = id
            };

            Assert.NotEqual(expectedPostUser, postUserActual);
        }
        #endregion

        private PostUser GetPostUserWithIdOne()
        { 
            return  new PostUser
            {
                UserId = 1,
                Id = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
        }

        private List<PostUser> GetPostsWithUserIdOne()
        {
            return new List<PostUser>
            {
                new PostUser
                {
                    UserId = 1,
                    Id = 1,
                    Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                    Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto"

                },
                new PostUser
                {
                    UserId = 1,
                    Id = 2,
                    Title = "qui est esse",
                    Body = "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut"
                }
            };
        }        
    }
}
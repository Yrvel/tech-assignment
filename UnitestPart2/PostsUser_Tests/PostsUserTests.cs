using PostAPI;

namespace UnitestPart2
{
    public class PostsUserTests
    {
        private readonly IPostsUserRepistory _postsUserRepistory;

        public PostsUserTests()
        {
            _postsUserRepistory = new PostsUserRepository();
        }

        #region PositiveScenarios

        [Fact]
        public void GetAllPostsUser_ShouldReturnAllPosts()
        {
            var postsUserActual = _postsUserRepistory.GetAllPostsUser();

            Assert.NotNull(postsUserActual);
            Assert.Equal(100, postsUserActual.Count);
        }

        [Fact]
        public void GetGroupPostsByUserId_ShouldReturnAllGroupPostsByUserId()
        {
            var groupingPostsUserActual = _postsUserRepistory.GetGroupPostsByUserId();

            Assert.NotNull(groupingPostsUserActual);

            foreach (var groupingPosts in groupingPostsUserActual)
            {
                Assert.Equal(10, groupingPosts.Value.Count);
            }

        }

        [Fact]
        public void GetAllPostsUser_ShouldSortingByIds()
        {
            var postsUserActual = _postsUserRepistory.GetAllPostsUser();
            var postsUserExpected = postsUserActual?.OrderBy(x => x.Id).ToList();
            Assert.NotNull(postsUserActual);
            Assert.True(postsUserExpected?.SequenceEqual(postsUserActual));
        }

        [Fact]
        public void GetPostById_ShouldReturnPostWithSameId()
        {
            var postUserActual = _postsUserRepistory.GetPostById(1);

            Assert.NotNull(postUserActual);
            Assert.Equal(1, postUserActual.Id);
        }

        [Fact]
        public void GetPostById_ShouldReturnSamePost()
        {
            var postUserActual = _postsUserRepistory.GetPostById(1);

            var postUserExpected = GetPostUserWithIdOne();

            Assert.NotNull(postUserActual);
            Assert.Equal(postUserExpected.Id, postUserActual.Id);
            Assert.Equal(postUserExpected.UserId, postUserActual.UserId);
            Assert.Equal(postUserExpected.Title, postUserActual.Title);
            Assert.Equal(postUserExpected.Body, postUserActual.Body);
        }

        [Fact]
        public void GetPostsByUserId_ShouldReturnAllsPostWithSameUserId()
        {
            var postsUserActual = _postsUserRepistory.GetPostsByUserId(1);

            Assert.NotNull(postsUserActual);
            Assert.Equal(10, postsUserActual.Count);
        }

        #endregion

        #region NegativeScenarios
        [Fact]
        public void GetPostById_ShouldNotReturnPostWithDifferentId()
        {
            var postsUserActual = _postsUserRepistory.GetPostById(1);

            Assert.NotNull(postsUserActual);
            Assert.NotEqual(2, postsUserActual.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(101)]
        public void GetPostById_ShouldNotReturnPostWithInvalidId(int? id)
        {
            var postsUserActual = _postsUserRepistory.GetPostById(id ?? 0);

            Assert.Null(postsUserActual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(11)]
        public void GetPostsByUserId_ShouldNotReturnAnyPostWithInvalidUserId(int? id)
        {
            var postsUserActual = _postsUserRepistory.GetPostsByUserId(id ?? 0);

            Assert.Empty(postsUserActual);
        }

        [Theory]
        [InlineData(1, null)]
        [InlineData(1, "")]
        public void GetPostById_ShouldNotReturnPostWithInvalidTitle(int id, string title)
        {
            var postsUserActual = _postsUserRepistory.GetPostById(id);

            Assert.NotNull(postsUserActual);
            Assert.NotEqual(title, postsUserActual.Title);
        }

        [Theory]
        [InlineData(1, null)]
        [InlineData(1, "")]
        public void GetPostById_ShouldNotReturnPostWithInvalidBody(int id, string body)
        {
            var postsUserActual = _postsUserRepistory.GetPostById(id);

            Assert.NotNull(postsUserActual);
            Assert.NotEqual(body, postsUserActual.Body);
        }
        #endregion

        private PostUser GetPostUserWithIdOne()
        {
            return new PostUser
            {
                UserId = 1,
                Id = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
        }
    }
}
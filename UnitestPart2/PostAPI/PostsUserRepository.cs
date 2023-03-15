using System.Net.Http.Json;

namespace PostAPI
{
    public class PostsUserRepository : IPostsUserRepistory
    {
        HttpClient client;
        private const string APIUrl = "https://jsonplaceholder.typicode.com/posts";
        private List<PostUser>? posts;

        public PostsUserRepository()
        {
            client = new HttpClient();

            using (HttpResponseMessage response = client.GetAsync(APIUrl).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    posts = response.Content.ReadFromJsonAsync<List<PostUser>>().Result;
                }
            }
        }

        public List<PostUser>? GetAllPostsUser()
        {
            return posts;
        }

        public PostUser? GetPostById(int id)
        {
            return posts?.FirstOrDefault(x => x.Id == id);
        }

        public List<PostUser> GetPostsByUserId(int userId)
        {
            return posts.Where(x => x.UserId == userId).ToList();
        }

        public Dictionary<int, List<PostUser>> GetGroupPostsByUserId()
        {
            if (posts == null)
            {
                return new Dictionary<int, List<PostUser>?>();
            }
            return posts.GroupBy(x => x.UserId).ToDictionary(d => d.Key, d => d.ToList());
        }
    }

    public interface IPostsUserRepistory
    {
        List<PostUser>? GetAllPostsUser();
        PostUser? GetPostById(int id);
        List<PostUser> GetPostsByUserId(int userId);
        Dictionary<int, List<PostUser>> GetGroupPostsByUserId();
    }
}
using System.IO;
using System.Net.Http.Json;

namespace PostAPI
{
    public class PostsUserRepository : IPostsUserRepistory
    {
        HttpClient client;
        private const string APIUrl = "https://jsonplaceholder.typicode.com/posts";
        public PostsUserRepository()
        {
            client = new HttpClient();
        }
        public async Task<List<PostUser>> GetAllPosts()
        {
            List<PostUser> posts =new List<PostUser>();
            HttpResponseMessage response = await client.GetAsync(APIUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content?.ReadFromJsonAsync<List<PostUser>>();
            }
            return posts;
        }
        public async Task<PostUser> GetPostById(int id)
        {
            using (HttpResponseMessage response = await client.GetAsync($"{APIUrl}/{id}").ConfigureAwait(false))
            {              
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content?.ReadFromJsonAsync<PostUser>();
                }

                return null;
            }
           
        }

        public async Task<List<PostUser>> GetPostsByUserId(int userId)
        {
            using (HttpResponseMessage response = await client.GetAsync($"{APIUrl}/{userId}").ConfigureAwait(false))
            {               
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content?.ReadFromJsonAsync<List<PostUser>>();
                }

                throw new ArgumentException();
            }

        }
    }

    public interface IPostsUserRepistory
    {
        Task<List<PostUser>> GetAllPosts();
        Task<PostUser> GetPostById(int id);
        Task<List<PostUser>> GetPostsByUserId(int userId);
    }
}
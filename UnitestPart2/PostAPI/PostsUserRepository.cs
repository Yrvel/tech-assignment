using System.Net.Http.Json;

namespace PostAPI
{
    //A repository to return posts
    public class PostsUserRepository : IPostsUserRepistory
    {
        HttpClient client;
        private const string APIUrl = "https://jsonplaceholder.typicode.com/posts";
        public PostsUserRepository()
        {
            client = new HttpClient();
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

                return null;
            }

        }
    }

    public interface IPostsUserRepistory
    {
        Task<PostUser> GetPostById(int id);
        Task<List<PostUser>> GetPostsByUserId(int userId);
    }
}
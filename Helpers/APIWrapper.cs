using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using phiPartners.Models;

namespace phiPartners.Helpers
{
    public class APIWrapper
    {
        const string urlStory = "https://hacker-news.firebaseio.com/v0/beststories.json";
        const string urlStoryItem = "https://hacker-news.firebaseio.com/v0/item/";

        public async Task<List<StoryItem>> GetHackerStories()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stories = await GetStories(client);

                if (stories == null)
                    return null;

                var tasks = new List<Task<StoryItem>>();

                foreach (var story in stories)
                    tasks.Add(GetStoryItem(story, client));

                var responses = await Task.WhenAll(tasks);

                return responses.Where(response => response != null).ToList();
            }
        }

        private async Task<List<int>> GetStories(HttpClient client)
        {
            using (var response = await client.GetAsync(urlStory))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<int>>();
                }
            }
            return null;
        }

        private async Task<StoryItem> GetStoryItem(int id, HttpClient client)
        {
            using (var response = await client.GetAsync(string.Concat(urlStoryItem, id, ".json")))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoryItem>();
                }
            }
            return null;
        }
    }
}

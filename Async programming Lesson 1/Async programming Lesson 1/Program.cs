using System.Text.Json;

namespace Async_programming_Lesson_1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var tasks = new List<Task<Model>>();
            for (uint i = 4; i <= 13; i++)
                tasks.Add(GetPostById(i));

            Task.WaitAll(tasks.ToArray());

            using (var sw = new StreamWriter(File.Create("result.txt")))
            {
                foreach (var task in tasks)
                    if (task.IsCompleted && task.Exception == null)
                        sw.WriteLine(task.Result);
            }
        }


        private static async Task<Model> GetPostById(uint id)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");

            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                if (await JsonSerializer.DeserializeAsync<Model>(responseStream, options) is Model model)
                    return model;
                else
                  throw new Exception($"Error content");               
            }
            else
            {
                throw new Exception($"Error code {response.StatusCode}");
            }
        }
    }
}
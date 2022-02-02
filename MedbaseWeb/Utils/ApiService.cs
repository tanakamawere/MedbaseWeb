namespace MedbaseWeb.Utils
{
    public class ApiService
    {
        private List<Question> questions;
        private List<Article> articles;
        private HttpClient _httpClient;
        public string GetAddress()
        {
            return "https://localhost:7076";
        }

        public PagedList<Question> GetQuestions(QueryOptions options)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/questions");

            HttpResponseMessage responseTask = _httpClient
                .GetAsync($"{_httpClient.BaseAddress}/{options.Topic}").Result;

            if (responseTask.IsSuccessStatusCode)
            {
                string? readJob = responseTask.Content.ReadAsStringAsync().Result;
                questions = JsonConvert.DeserializeObject<List<Question>>(readJob);
            }
            return new PagedList<Question>(questions, options);
        }
        public List<Question> GetRandomQuestions(int topic, int number)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/questions");

            HttpResponseMessage responseTask = _httpClient
                .GetAsync($"{_httpClient.BaseAddress}/{topic}/{number}").Result;

            if (responseTask.IsSuccessStatusCode)
            {
                string? readJob = responseTask.Content.ReadAsStringAsync().Result;
                questions = JsonConvert.DeserializeObject<List<Question>>(readJob);
            }
            return questions;
        }
        public List<Article> GetHomeArticles()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync($"{_httpClient.BaseAddress}/select/3").Result;

            Console.WriteLine(_httpClient.BaseAddress.ToString());

            if (responseTask.IsSuccessStatusCode)
            {
                string readJob = responseTask.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<List<Article>>(readJob);
            }
            return articles;
        }
        public List<Article> GetArticles()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            if (responseTask.IsSuccessStatusCode)
            {
                string readJob = responseTask.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<List<Article>>(readJob);
            }
            return articles;
        }
        public Article GetArticle(int id)
        {
            Article article = new Article();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;

            if (responseTask.IsSuccessStatusCode)
            {
                string readJob = responseTask.Content.ReadAsStringAsync().Result;
                article = JsonConvert.DeserializeObject<Article>(readJob);
            }
            return article;
        }
    }
}

namespace MedbaseWeb.Utils
{
    public class ApiService
    {
        private List<Question>? questions;
        private List<Article>? articles;
        private HttpClient? _httpClient;
        public string GetAddress()
        {
            return "https://medbaseapi.azurewebsites.net";
        }

        public PagedList<Question> GetQuestions(QueryOptions options)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/questions");

            HttpResponseMessage responseTask = _httpClient
                .GetAsync($"{_httpClient.BaseAddress}/{options.Topic}").Result;

            try
            {
                if (responseTask.IsSuccessStatusCode)
                {
                    string? readJob = responseTask.Content.ReadAsStringAsync().Result;
                    questions = JsonConvert.DeserializeObject<List<Question>>(readJob);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new PagedList<Question>(questions, options);
        }
        public List<Question> GetRandomQuestions(int topic, int number)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/questions");

            HttpResponseMessage responseTask = _httpClient
                .GetAsync($"{_httpClient.BaseAddress}/{topic}/{number}").Result;

            try
            {
                if (responseTask.IsSuccessStatusCode)
                {
                    string? readJob = responseTask.Content.ReadAsStringAsync().Result;
                    questions = JsonConvert.DeserializeObject<List<Question>>(readJob);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return questions;
        }
        public List<Article> GetHomeArticles()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync($"{_httpClient.BaseAddress}/select/3").Result;

            try
            {
                if (responseTask.IsSuccessStatusCode)
                {
                    string readJob = responseTask.Content.ReadAsStringAsync().Result;
                    articles = JsonConvert.DeserializeObject<List<Article>>(readJob);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return articles;
        }
        public List<Article> GetArticles()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            try
            {
                if (responseTask.IsSuccessStatusCode)
                {
                    string readJob = responseTask.Content.ReadAsStringAsync().Result;
                    articles = JsonConvert.DeserializeObject<List<Article>>(readJob);
                }
            }
            catch (Exception)
            {
                throw;
            }
            articles?.Reverse();
            return articles;
        }
        public Article GetArticle(int id)
        {
            Article article = new Article();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{GetAddress()}/articles");
            HttpResponseMessage responseTask = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;

            try
            {
                if (responseTask.IsSuccessStatusCode)
                {
                    string readJob = responseTask.Content.ReadAsStringAsync().Result;
                    article = JsonConvert.DeserializeObject<Article>(readJob);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return article;
        }
    }
}

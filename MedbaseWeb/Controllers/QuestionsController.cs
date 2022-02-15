using MedbaseWeb.Utils;

namespace MedbaseWeb.Controllers
{
    public class QuestionsController : Controller
    {
        List<string> Courses;
        List<Topic> anatomy;
        List<Topic> physiology;
        List<Topic> topic;
        List<Question> questions1;
        HttpClient _httpClient;
        public ApiService apiService;

        public QuestionsController()
        {
            Courses = new List<string>();
            topic = new List<Topic>();
            apiService = new ApiService();

            Courses.Add("Physiology");
            Courses.Add("Anatomy");
            anatomy = new List<Topic>()
            {
                new Topic() { Id = 1, Name = "Upper Limb" },
                new Topic() { Id = 2, Name = "Thorax" },
                new Topic() { Id = 3, Name = "Abdomen" },
                new Topic() { Id = 4, Name = "Pelvis & Perineum" },
                new Topic() { Id = 5, Name = "Lower Limb" },
                new Topic() { Id = 6, Name = "Head & Neck" },
            };
            physiology = new List<Topic>()
            {
                new Topic() { Id = 7, Name="Cell"},
                new Topic() { Id = 8, Name="Nerve & Muscle"},
                new Topic() { Id = 9, Name="Blood"},
                new Topic() { Id = 10, Name="Endocrinology"},
                new Topic() { Id = 11, Name="GIT"},
                new Topic() { Id = 12, Name="Reproduction"},
                new Topic() { Id = 13, Name="Cardiovascular System"},
                new Topic() { Id = 14, Name="Renal"},
                new Topic() { Id = 15, Name="Respiratory"},
                new Topic() { Id = 16, Name="Neurophysiology"},
            };

            questions1 = new List<Question>();
            _httpClient = new HttpClient();
        }
        [Route("anatomy")]
        public IActionResult Anatomy(QueryOptions options)
        {
            if (options.AnswerVisibility == 1)
            {
                ViewBag.Visibility = 1;
            }
            else 
            {
                ViewBag.Visibility = 0;
            }
            return View(apiService.GetQuestions(options));
        }
        [Route("physiology")]
        public IActionResult Physiology(QueryOptions options)
        {
            if (options.AnswerVisibility == 1)
            {
                ViewBag.Visibility = 1;
            }
            else
            {
                ViewBag.Visibility = 0;
            }
            return View(apiService.GetQuestions(options));
        }
        [Route("pharmacology")]
        public IActionResult Pharmacology(QueryOptions options)
        {
            if (options.AnswerVisibility == 1)
            {
                ViewBag.Visibility = 1;
            }
            else
            {
                ViewBag.Visibility = 0;
            }
            return View(apiService.GetQuestions(options));
        }
        public IActionResult Index(int topicSelected)
        {
            return View(apiService.GetRandomQuestions(topicSelected, 20));
        }
        private string ConvertTopicString(int topic)
        {
            string topicString = "";

            foreach (Topic item in physiology)
            {
                if (item.Id == topic)
                {
                    topicString = item.Name;
                }
                else
                {
                }
            }
            foreach (Topic item in anatomy)
            {
                if (item.Id == topic)
                {
                    topicString = item.Name;
                }
                else
                {
                }
            }
            return topicString;
        }
    }
}

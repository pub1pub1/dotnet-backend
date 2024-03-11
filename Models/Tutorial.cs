namespace TutorialApi.Models
{
    public class Tutorial
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
    }
}
using Newtonsoft.Json;

namespace eBooks.API.Entities
{
    public class Books
    {
        public int Id { get; set; }       
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public List<string> Genre { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
    }
}

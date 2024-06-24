using Newtonsoft.Json;

namespace eBooks.API.Entities
{
    public class Books
    {
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publication_year")]
        public int PublicationYear { get; set; }

        [JsonProperty("genre")]
        public List<string> Genre { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }
    }
}

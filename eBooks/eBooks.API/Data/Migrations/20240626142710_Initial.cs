using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eBooks.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImage", "Description", "Genre", "Liked", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", "https://fakeimg.pl/667x1000/cc6600", "A classic novel depicting racial injustice in the American South.", "Fiction,Classic", null, 1960, "To Kill a Mockingbird" },
                    { 2, "George Orwell", "https://fakeimg.pl/667x1000/cc6600", "A dystopian novel portraying a totalitarian society.", "Dystopian,Science Fiction", null, 1949, "1984" },
                    { 3, "Jane Austen", "https://fakeimg.pl/667x1000/cc6600", "A classic novel exploring themes of love, marriage, and social norms.", "Classic,Romance", null, 1813, "Pride and Prejudice" },
                    { 4, "F. Scott Fitzgerald", "https://fakeimg.pl/667x1000/cc6600", "A tale of the American Dream, wealth, and love during the Roaring Twenties.", "Fiction,Classic", null, 1925, "The Great Gatsby" },
                    { 5, "Herman Melville", "https://fakeimg.pl/667x1000/cc6600", "The epic tale of Captain Ahab's obsession with the white whale.", "Fiction,Adventure", null, 1851, "Moby-Dick" },
                    { 6, "J.R.R. Tolkien", "https://fakeimg.pl/667x1000/cc6600", "An epic fantasy saga about the quest to destroy the One Ring.", "Fantasy,Adventure", null, 1954, "The Lord of the Rings" },
                    { 7, "J.D. Salinger", "https://fakeimg.pl/667x1000/cc6600", "A classic coming-of-age novel following Holden Caulfield's journey.", "Fiction,Coming-of-age", null, 1951, "The Catcher in the Rye" },
                    { 8, "J.R.R. Tolkien", "https://fakeimg.pl/667x1000/cc6600", "The prequel to The Lord of the Rings, following Bilbo Baggins' journey.", "Fantasy,Adventure", null, 1937, "The Hobbit" },
                    { 9, "Gabriel Garcia Marquez", "https://fakeimg.pl/667x1000/cc6600", "A multi-generational saga of the Buendía family in the fictional town of Macondo.", "Magical Realism,Literary Fiction", null, 1967, "One Hundred Years of Solitude" },
                    { 10, "Leo Tolstoy", "https://fakeimg.pl/667x1000/cc6600", "A monumental work depicting the events of Russian society during the Napoleonic era.", "Historical Fiction,Epic", null, 1869, "War and Peace" },
                    { 11, "Homer", "https://fakeimg.pl/667x1000/cc6600", "An ancient Greek epic poem recounting Odysseus' ten-year journey home after the Trojan War.", "Epic,Mythology", null, -800, "The Odyssey" },
                    { 12, "Dante Alighieri", "https://fakeimg.pl/667x1000/cc6600", "An epic poem that follows the journey of the soul through Hell, Purgatory, and Heaven.", "Epic,Poetry", null, 1320, "The Divine Comedy" },
                    { 13, "Fyodor Dostoevsky", "https://fakeimg.pl/667x1000/cc6600", "A complex novel exploring themes of spirituality, morality, and human nature.", "Classic,Philosophical Fiction", null, 1880, "The Brothers Karamazov" },
                    { 14, "Fyodor Dostoevsky", "https://fakeimg.pl/667x1000/cc6600", "A psychological thriller revolving around guilt, conscience, and redemption.", "Classic,Psychological Fiction", null, 1866, "Crime and Punishment" },
                    { 15, "Oscar Wilde", "https://fakeimg.pl/667x1000/cc6600", "A novel about a man whose portrait ages while he retains his youth and beauty.", "Gothic,Philosophical Fiction", null, 1890, "The Picture of Dorian Gray" },
                    { 16, "Aldous Huxley", "https://fakeimg.pl/667x1000/cc6600", "A dystopian vision of a future society obsessed with pleasure and conformity.", "Dystopian,Science Fiction", null, 1932, "Brave New World" },
                    { 17, "Alexandre Dumas", "https://fakeimg.pl/667x1000/cc6600", "An adventure novel of revenge, love, and redemption set in the early 19th century.", "Adventure,Historical Fiction", null, 1844, "The Count of Monte Cristo" },
                    { 18, "Leo Tolstoy", "https://fakeimg.pl/667x1000/cc6600", "A tragic love story set against the backdrop of Russian high society.", "Classic,Romance", null, 1877, "Anna Karenina" },
                    { 19, "Paulo Coelho", "https://fakeimg.pl/667x1000/cc6600", "A philosophical novel about a shepherd boy's journey to find his personal legend.", "Fiction,Philosophical", null, 1988, "The Alchemist" },
                    { 20, "Mark Twain", "https://fakeimg.pl/667x1000/cc6600", "A satirical novel following Huck Finn's journey down the Mississippi River.", "Adventure,Satire", null, 1884, "The Adventures of Huckleberry Finn" },
                    { 21, "Homer", "https://fakeimg.pl/667x1000/cc6600", "An ancient Greek epic poem about the Trojan War and the hero Achilles.", "Epic,Mythology", null, -800, "The Iliad" },
                    { 22, "J.R.R. Tolkien", "https://fakeimg.pl/667x1000/cc6600", "A thrilling epic about the quest to destroy the One Ring and save Middle-earth.", "Fantasy,Adventure", null, 1954, "The Lord of the Rings" },
                    { 23, "Mary Shelley", "https://fakeimg.pl/667x1000/cc6600", "A Gothic novel exploring themes of creation, science, and humanity.", "Gothic,Science Fiction", null, 1818, "Frankenstein" },
                    { 24, "Miguel de Cervantes", "https://fakeimg.pl/667x1000/cc6600", "A humorous novel about an elderly knight who sets out on a quest to revive chivalry.", "Classic,Satire", null, 1605, "Don Quixote" },
                    { 25, "Lewis Carroll", "https://fakeimg.pl/667x1000/cc6600", "A whimsical tale about a girl who falls down a rabbit hole into a fantastical world.", "Fantasy,Children's Literature", null, 1865, "Alice's Adventures in Wonderland" },
                    { 26, "Antoine de Saint-Exupéry", "https://fakeimg.pl/667x1000/cc6600", "A philosophical novella about a young prince's journey through the universe.", "Fable,Children's Literature", null, 1943, "The Little Prince" },
                    { 27, "Markus Zusak", "https://fakeimg.pl/667x1000/cc6600", "A story of a girl living in Nazi Germany, narrated by Death.", "Historical Fiction,War", null, 2005, "The Book Thief" },
                    { 28, "Kurt Vonnegut", "https://fakeimg.pl/667x1000/cc6600", "An anti-war novel that mixes science fiction and dark humor.", "Satire,Science Fiction", null, 1969, "Slaughterhouse-Five" },
                    { 29, "John Steinbeck", "https://fakeimg.pl/667x1000/cc6600", "A novel about the plight of migrant workers during the Great Depression.", "Historical Fiction,Social Commentary", null, 1939, "The Grapes of Wrath" },
                    { 30, "Ray Bradbury", "https://fakeimg.pl/667x1000/cc6600", "A dystopian novel depicting a future society where books are banned.", "Dystopian,Science Fiction", null, 1953, "Fahrenheit 451" },
                    { 31, "William Golding", "https://fakeimg.pl/667x1000/cc6600", "A novel about a group of British boys stranded on an uninhabited island.", "Dystopian,Psychological Fiction", null, 1954, "The Lord of the Flies" },
                    { 32, "Douglas Adams", "https://fakeimg.pl/667x1000/cc6600", "A comedic science fiction series about the misadventures of Arthur Dent.", "Science Fiction,Comedy", null, 1979, "The Hitchhiker's Guide to the Galaxy" },
                    { 33, "Charles Dickens", "https://fakeimg.pl/667x1000/cc6600", "A historical novel set during the French Revolution, exploring themes of sacrifice and resurrection.", "Historical Fiction,Classic", null, 1859, "A Tale of Two Cities" },
                    { 34, "C.S. Lewis", "https://fakeimg.pl/667x1000/cc6600", "A series of fantasy novels set in the magical land of Narnia.", "Fantasy,Children's Literature", null, 1950, "The Chronicles of Narnia" },
                    { 35, "Margaret Atwood", "https://fakeimg.pl/667x1000/cc6600", "A dystopian novel set in a totalitarian society where women are subjugated.", "Dystopian,Feminist Fiction", null, 1985, "The Handmaid's Tale" },
                    { 36, "Umberto Eco", "https://fakeimg.pl/667x1000/cc6600", "A medieval mystery novel set in an Italian monastery.", "Historical Fiction,Mystery", null, 1980, "The Name of the Rose" },
                    { 37, "Franz Kafka", "https://fakeimg.pl/667x1000/cc6600", "A surreal novel exploring themes of guilt, law, and justice.", "Absurdist Fiction,Existential", null, 1925, "The Trial" },
                    { 38, "Khaled Hosseini", "https://fakeimg.pl/667x1000/cc6600", "A novel about friendship, redemption, and the impact of war in Afghanistan.", "Historical Fiction,Drama", null, 2003, "The Kite Runner" },
                    { 39, "Ken Follett", "https://fakeimg.pl/667x1000/cc6600", "An epic historical novel set in 12th-century England, centered around the construction of a cathedral.", "Historical Fiction,Adventure", null, 1989, "The Pillars of the Earth" },
                    { 40, "Carlos Ruiz Zafón", "https://fakeimg.pl/667x1000/cc6600", "A mystery novel set in post-war Barcelona, revolving around a forgotten book and its author.", "Mystery,Gothic", null, 2001, "The Shadow of the Wind" },
                    { 41, "Frances Hodgson Burnett", "https://fakeimg.pl/667x1000/cc6600", "A classic children's novel about a young girl who discovers a hidden garden.", "Children's Literature,Classic", null, 1911, "The Secret Garden" },
                    { 42, "Lois Lowry", "https://fakeimg.pl/667x1000/cc6600", "A dystopian novel about a society with strict control over emotions and memories.", "Dystopian,Young Adult", null, 1993, "The Giver" },
                    { 43, "Franz Kafka", "https://fakeimg.pl/667x1000/cc6600", "A novella about a man who wakes up one morning transformed into a giant insect.", "Absurdist Fiction,Existential", null, 1915, "The Metamorphosis" },
                    { 44, "Margaret Mitchell", "https://fakeimg.pl/667x1000/cc6600", "A historical novel set during the American Civil War, centered around Scarlett O'Hara.", "Historical Fiction,Romance", null, 1936, "Gone with the Wind" },
                    { 45, "Kenneth Grahame", "https://fakeimg.pl/667x1000/cc6600", "A children's novel about the adventures of anthropomorphic animals.", "Children's Literature,Fantasy", null, 1908, "The Wind in the Willows" },
                    { 46, "Bram Stoker", "https://fakeimg.pl/667x1000/cc6600", "A Gothic horror novel about the vampire Count Dracula's attempt to move to England.", "Gothic,Horror", null, 1897, "Dracula" },
                    { 47, "Jack London", "https://fakeimg.pl/667x1000/cc6600", "An adventure novel about a domestic dog's life in the wilds of the Yukon.", "Adventure,Nature", null, 1903, "The Call of the Wild" },
                    { 48, "Stephen King", "https://fakeimg.pl/667x1000/cc6600", "A post-apocalyptic horror novel about a deadly pandemic and its aftermath.", "Horror,Post-Apocalyptic", null, 1978, "The Stand" },
                    { 49, "Alice Walker", "https://fakeimg.pl/667x1000/cc6600", "A novel about the life of African-American women in the Southern United States.", "Fiction,Historical", null, 1982, "The Color Purple" },
                    { 50, "J.R.R. Tolkien", "https://fakeimg.pl/667x1000/cc6600", "A collection of mythopoeic stories about the history of Middle-earth.", "Fantasy,Mythopoeia", null, 1977, "The Silmarillion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

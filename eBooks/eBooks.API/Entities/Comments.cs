﻿namespace eBooks.API.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int BookId { get; set; }
        public Books Book { get; set; }
    }
}

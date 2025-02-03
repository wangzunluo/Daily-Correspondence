using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Daily_Correspondence.Models
{
    public class Letter
    {
        public Letter() { }

        [SetsRequiredMembers]
        public Letter(int id, string author, DateTime publishDate, string body, string? subject) =>
            (Id, Author, PublishDate, Body, Subject) = (id, author, publishDate, body, subject);

        public int Id { get; set; }
        public required string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public required string Body { get; set; }
        public string? Subject { get; set; }

    }

    
}



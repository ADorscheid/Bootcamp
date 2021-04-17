using System;

namespace Blogs
{
    public class Post
    {
        public Post()
        { }

        public Post(string name, string body, bool isPublished, DateTime created)
        {
            Body = body;
            Created = created;
            IsPublished = isPublished;
            Name = name;
        }

        public string Body { get; set; }
        public DateTime Created { get; set; }
        public long Id { get; set; }
        public bool IsPublished { get; set; }
        public string Name { get; set; }
    }
}

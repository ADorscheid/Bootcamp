using System.Collections.Generic;

namespace Blogs
{
    public interface IPostDao
    {
        void Save(Post newPost);
        IList<Post> GetAllPosts();
    }
}
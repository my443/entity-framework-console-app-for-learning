
namespace EntityFrameworkCoreLearning
{
    class TestClass
    {
        static void Main(string[] args)
        {
            BloggingContext myBloggingContext = new BloggingContext();
            Blog myBlog = new Blog { Url = "http://blogs.msdn.com/adonet" };

            myBloggingContext.Add(myBlog);
            myBloggingContext.SaveChanges();

            IQueryable<Blog> query = getBlogEntries(myBloggingContext);

            foreach (Blog blog in query)
            {
                Console.WriteLine(blog.Url);
            }

            // Display the number of command line arguments.
            Console.WriteLine("This works now.");
        }

        static IQueryable<Blog> getBlogEntries(BloggingContext myBloggingContext) {

            IQueryable<Blog> blogQuery =
                from blog in myBloggingContext.Blogs
                //where cust.City == "London"
                select blog;

            return blogQuery;
        }
    }
}
    

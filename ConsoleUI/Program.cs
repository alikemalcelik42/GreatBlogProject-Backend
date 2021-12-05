using Business.Concrete;
using DataAccess.Concrete;

BlogManager blogManager = new BlogManager(new EfBlogDal());

var result = blogManager.GetAll();

if(result.Success)
{
    foreach(var blog in result.Data)
    {
        Console.WriteLine(blog.Title);
    }
}
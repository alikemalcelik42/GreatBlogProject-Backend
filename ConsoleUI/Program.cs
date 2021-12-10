using Business.Concrete;
using DataAccess.Concrete;

CommentManager commentManager = new CommentManager(new EfCommentDal());

var result = commentManager.GetAll();

if(result.Success)
{
    foreach(var comment in result.Data)
    {
        Console.WriteLine(comment.Content);
    }
    Console.WriteLine(result.Message);
}
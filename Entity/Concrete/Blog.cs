using Core.Entites.Abstract;

namespace Entity.Concrete
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

using Core.Entites.Abstract;

namespace Entity.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

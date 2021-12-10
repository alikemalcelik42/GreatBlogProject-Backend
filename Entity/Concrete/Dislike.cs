using Core.Entites.Abstract;

namespace Entity.Concrete
{
    public class Dislike : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}

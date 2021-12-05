using Core.Entites.Abstract;

namespace Entity.DTOs
{
    public class CommentDetailDto : IDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

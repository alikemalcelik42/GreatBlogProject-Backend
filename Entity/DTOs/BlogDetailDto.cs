using Core.Entites.Abstract;

namespace Entity.DTOs
{
    public class BlogDetailDto : IDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageFilePath { get; set; }
        public string ImageRootPath { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

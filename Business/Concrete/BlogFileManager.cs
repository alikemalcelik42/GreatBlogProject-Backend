using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogFileManager : IFileService
    {
        public readonly string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public readonly string url = "https://localhost:7263";
        public readonly string currentFolder = "BlogImages";

        public BlogFileManager()
        {
            this.root = Path.Combine(root, currentFolder);
        }

        public IDataResult<FileDetailDto> Add(IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string guid = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(fileName);
            string newFileName = guid + fileExtension;

            string filePath = Path.Combine(root, newFileName);
            string rootPath = $@"{url}/{currentFolder}/{newFileName}";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
                return new SuccessDataResult<FileDetailDto>(new FileDetailDto()
                {
                    FilePath = filePath,
                    RootPath = rootPath
                }, Messages.FileCreated);
            }
        }

        public IResult Delete(string path)
        {
            File.Delete(path);
            return new SuccessResult(Messages.FileDeleted);
        }

        public IDataResult<FileDetailDto> Update(string oldFilePath, IFormFile file)
        {
            Delete(oldFilePath);
            return Add(file);
        }
    }
}

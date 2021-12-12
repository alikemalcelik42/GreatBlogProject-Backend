using Core.Utilities.Results.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Business.Abstract
{
    public interface IFileService
    {
        IDataResult<FileDetailDto> Add(IFormFile file);
        IDataResult<FileDetailDto> Update(string oldFilePath, IFormFile file);
        IResult Delete(string filePath);
    }
}

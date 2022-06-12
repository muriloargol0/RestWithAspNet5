using Microsoft.AspNetCore.Http;
using RestWithAspNet.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithAspNet.Business
{
    public interface IFileBusiness
    {
        byte[] GetFile(string fileName);
        Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}

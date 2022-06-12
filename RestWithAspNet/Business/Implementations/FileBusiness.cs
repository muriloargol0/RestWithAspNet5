using Microsoft.AspNetCore.Http;
using RestWithAspNet.Data.VO;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestWithAspNet.Business.Implementations
{
    public class FileBusiness : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusiness(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = string.Concat(Directory.GetCurrentDirectory(), "\\UploadDir\\");
        }

        public byte[] GetFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file)
        {
            List<FileDetailVO> result = new List<FileDetailVO>();

            Parallel.ForEach(file, i => {
                result.Add(SaveFileToDisk(i).Result);
            });

            return result;
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            //Get server address
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower().Equals(".pdf")
                || fileType.ToLower().Equals(".jpg")
                || fileType.ToLower().Equals(".png")
                || fileType.ToLower().Equals(".jpeg"))
            {
                var docName = Path.GetFileName(file.FileName);

                if(file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.DocumentName = docName;
                    fileDetail.DocumentType = fileType;
                    fileDetail.DocUrl = Path.Combine(baseUrl.ToString(), "/api/file", fileDetail.DocumentName);

                    using (var stream = new FileStream(destination, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            return fileDetail;
        }
    }
}

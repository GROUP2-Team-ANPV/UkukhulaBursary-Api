using Microsoft.AspNetCore.Http;

namespace DataAccess.Models
{
    public class UploadDocument
    {
        
        public required IFormFile File { get; set; }
        public int DocumentType { get; set; }

    }
}

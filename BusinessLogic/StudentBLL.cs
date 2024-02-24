using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DataAccess.Entity;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic
{
    public class StudentBLL
    {
        private readonly StudentDAL _uploadDocumentDAL;

        public StudentBLL(StudentDAL uploadDocumentDAL)
        {
            _uploadDocumentDAL = uploadDocumentDAL;
        }

        public async Task<ActionResult> UploadDocument(int requestID, Models.UploadDocument uploadDocument)
        {
            try
            {
                UploadDocument upload = new()
                {
                    File = uploadDocument.File,
                    DocumentType = uploadDocument.DocumentType
                };
                return await _uploadDocumentDAL.UploadDocument(requestID, upload);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading document: {ex.Message}");
            }
        }
    }
}

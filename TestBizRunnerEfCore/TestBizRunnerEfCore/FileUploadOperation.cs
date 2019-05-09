using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TestBizRunnerEfCore
{
    public class FileUploadOperation : IOperationFilter
    {
        private readonly List<string> _fileUploadOperationIdList = new List<string> {
            "maintenanceworkordercreatemaintenanceworkorder"
        };

        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (_fileUploadOperationIdList.Contains(operation.OperationId.ToLower()))
            {
                operation.Parameters = operation.Parameters.Where(p => p.Name != "uploadedFile").ToList();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "uploadedFile",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}

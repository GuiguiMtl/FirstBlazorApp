using System;
using System.Collections.Generic;
using System.Text;
using Shared.Enums;

namespace Shared.Dtos
{
    public class OperationDto
    {
        public OperationType OperationType { get; set; }
        public EmrDto Emr { get; set; }
        public EmrDto ParentEmr { get; set; }
        public string ParentFloc { get; set; }

        public bool ParentExists { get; set; }

    }
}

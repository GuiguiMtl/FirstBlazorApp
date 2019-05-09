using Shared.Dtos;
using Shared.Enums;

namespace DataLayer.Dtos
{
    public class MaintenanceWorkOrderOperationDto
    {
        public OperationType OperationType { get; set; }
        public string ParentFloc { get; set; }
        public EmrDto Emr { get; set; }
        public EmrDto ParentEmr { get; set; }
    }
    
}

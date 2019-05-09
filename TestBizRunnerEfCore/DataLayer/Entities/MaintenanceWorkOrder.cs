using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Dtos;
using GenericBizRunner;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Dtos;

namespace DataLayer.Entities
{
    public class MaintenanceWorkOrder
    {
        public Guid MaintenanceWorkOrderId { get; private set; }
        public string MWO_Number { get; private set; }
        public string MWO_Type { get; private set; }
        public DateTime MWO_CloseDate { get; private set; }
        public string SB_Number { get; private set; }
        public string SB_Revision { get; private set; }
        public List<Operation> Operations { get; private set; }

        public static IStatusGeneric<MaintenanceWorkOrder> CreateMaintenanceWorkOrderFactory(
            string MwoNumber, 
            string MWO_Type, 
            DateTime MwoCloseDate, 
            string SbNumber, 
            string SbRevision,
            List<OperationDto> operations)
        {
            var status = new StatusGenericHandler<MaintenanceWorkOrder>();

            if (!operations.Any())
            {
                status.AddError("No operation associated to Maintenance Work Order");
            }

            MaintenanceWorkOrder mwo = new MaintenanceWorkOrder
            {
                MaintenanceWorkOrderId = Guid.NewGuid(),
                MWO_Number = MwoNumber,
                MWO_Type = MWO_Type,
                MWO_CloseDate = MwoCloseDate,
                SB_Number = SbNumber,
                SB_Revision = SbRevision,
                Operations = new List<Operation>()
            };

            foreach (var operation in operations)
            {
                if (string.IsNullOrEmpty(operation.ParentFloc))
                {
                    var operationStatus = Operation.CreateOperationFactory(mwo.MaintenanceWorkOrderId, operation.Emr, operation.ParentEmr, operation.OperationType);
                    status.CombineErrors(operationStatus);
                    mwo.Operations.Add(operationStatus.Result);
                }
                else
                {
                    var operationStatus = Operation.CreateOperationFactory(mwo.MaintenanceWorkOrderId, operation.Emr, operation.ParentFloc, operation.OperationType);
                    status.CombineErrors(operationStatus);
                    mwo.Operations.Add(operationStatus.Result);
                }
            }

            status.Result = mwo;

            return status;
        }
    }
}

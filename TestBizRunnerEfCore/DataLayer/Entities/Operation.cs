using System;
using System.Collections.Generic;
using System.Text;
using GenericBizRunner;
using Shared.Dtos;
using Shared.Enums;

namespace DataLayer.Entities
{
    public class Operation
    {
        public Guid OperationId { get; private set; }
        public OperationType Type { get; private set; }
        public Guid MaintenanceWorkOrderId { get; private set; }
        public MaintenanceWorkOrder MaintenanceWorkOrder { get; private set; }

        public Emr Emr { get; set; }
        public Emr ParentEmr { get; set; }
        public string ParentFloc { get; set; }

        public static IStatusGeneric<Operation> CreateOperationFactory(Guid maintenanceWorkOrderId, EmrDto emrDto, EmrDto parentEmrDto,  OperationType type)
        {
            var status = new StatusGenericHandler<Operation>();
            status.Result = new Operation
            {
                OperationId = Guid.NewGuid(),
                Type = type,
                MaintenanceWorkOrderId = maintenanceWorkOrderId,
                Emr = new Emr
                {
                    Cage = emrDto.Cage,
                    Mpn = emrDto.Mpn,
                    Msn = emrDto.Msn
                },
                ParentEmr = new Emr
                {
                    Cage = parentEmrDto.Cage,
                    Mpn = parentEmrDto.Mpn,
                    Msn = parentEmrDto.Msn
                }
            };

            return status;
        }

        public static IStatusGeneric<Operation> CreateOperationFactory(Guid maintenanceWorkOrderId, EmrDto emrDto, string parentFloc,  OperationType type)
        {
            var status = new StatusGenericHandler<Operation>();
            status.Result = new Operation
            {
                OperationId = Guid.NewGuid(),
                Type = type,
                MaintenanceWorkOrderId = maintenanceWorkOrderId,
                Emr = new Emr
                {
                    Cage = emrDto.Cage,
                    Mpn = emrDto.Mpn,
                    Msn = emrDto.Msn
                },
                ParentFloc = parentFloc
            };

            return status;
        }
    }

    public class Emr
    {
        public string Cage { get; set; }
        public string Mpn { get; set; }
        public string Msn { get; set; }
    }
}

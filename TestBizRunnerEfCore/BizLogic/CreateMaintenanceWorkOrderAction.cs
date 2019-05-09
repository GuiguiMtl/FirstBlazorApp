using System;
using System.Collections.Generic;
using System.Text;
using BizDbAccess;
using DataLayer.Dtos;
using DataLayer.Entities;
using GenericBizRunner;

namespace BizLogic
{
    public class CreateMaintenanceWorkOrderAction : BizActionStatus, ICreateMaintenanceWorkOrderAction
    {
        private readonly ICreateMaintenanceWorkOrderDbAccess _dbAccess;

        public CreateMaintenanceWorkOrderAction(ICreateMaintenanceWorkOrderDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public MaintenanceWorkOrder BizAction(MaintenanceWorkOrderDto inputData)
        {
            IStatusGeneric<MaintenanceWorkOrder> maintenanceWorkOrderStatus = MaintenanceWorkOrder.CreateMaintenanceWorkOrderFactory
                (inputData.MWO_Number, inputData.MWO_Type, inputData.MWO_CloseDate, inputData.SB_Number, inputData.SB_Revision, inputData.Operations);

            CombineErrors(maintenanceWorkOrderStatus);

            if(!HasErrors)
                _dbAccess.Add(maintenanceWorkOrderStatus.Result);

            return HasErrors ? null : maintenanceWorkOrderStatus.Result;
        }
    }
}

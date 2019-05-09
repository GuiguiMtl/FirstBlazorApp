using DataLayer.Entities;
using GenericBizRunner;

namespace BizLogic
{
    public interface ICreateMaintenanceWorkOrderAction : IGenericActionWriteDb<MaintenanceWorkOrderDto, MaintenanceWorkOrder> { }
    
}
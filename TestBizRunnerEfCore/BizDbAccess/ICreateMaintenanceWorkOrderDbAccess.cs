using DataLayer.Entities;

namespace BizDbAccess
{
    public interface ICreateMaintenanceWorkOrderDbAccess
    {
        void Add(MaintenanceWorkOrder mwo);
    }
}
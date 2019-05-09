namespace ServiceLayer
{
    public interface ICreateMaintenanceWorkOrderService
    {
        void CreateMaintenanceWorkOrder(MaintenanceWorkOrderXmlDto dto);
    }
}
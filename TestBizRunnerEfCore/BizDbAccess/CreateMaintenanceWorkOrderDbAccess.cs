using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Entities;

namespace BizDbAccess
{
    public class CreateMaintenanceWorkOrderDbAccess : ICreateMaintenanceWorkOrderDbAccess
    {
        private readonly MwoContext _context;
        public CreateMaintenanceWorkOrderDbAccess(MwoContext context)
        {
            _context = context;
        }
        public void Add(MaintenanceWorkOrder mwo)
        {
            _context.Add(mwo);
        }
    }
}

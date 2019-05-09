using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizDbAccess.Configuration;
using BizLogic;
using DataLayer;
using DataLayer.Entities;
using GenericBizRunner;
using Shared.Dtos;
using Shared.Enums;

namespace ServiceLayer
{
    public class CreateMaintenanceWorkOrderService : ICreateMaintenanceWorkOrderService
    {
        private readonly IActionService<ICreateMaintenanceWorkOrderAction> _service;
        private readonly ISearchFlocApi _searchFlocApi;

        public CreateMaintenanceWorkOrderService(IActionService<ICreateMaintenanceWorkOrderAction> service, ISearchFlocApi searchFlocApi)
        {
            _service = service;
            _searchFlocApi = searchFlocApi;
        }

        public void CreateMaintenanceWorkOrder(MaintenanceWorkOrderXmlDto dto)
        {
            
            var operationsBizDto = new List<OperationDto>();
            foreach (var maintenanceWorkOrderOperationXmlDto in dto.Operations)
            {
                EmrDto parentEmr = null;
                if (maintenanceWorkOrderOperationXmlDto.ParentEmr != null)
                {
                    parentEmr = new EmrDto
                    {
                        Cage = maintenanceWorkOrderOperationXmlDto.ParentEmr.Cage,
                        Mpn = maintenanceWorkOrderOperationXmlDto.ParentEmr.Mpn,
                        Msn = maintenanceWorkOrderOperationXmlDto.ParentEmr.Msn,
                    };
                }

                var parentFlocDetails = _searchFlocApi.SearchFlocByName(maintenanceWorkOrderOperationXmlDto.ParentFloc);

                var operation = new OperationDto
                {
                    OperationType = maintenanceWorkOrderOperationXmlDto.Type == "U"
                        ? OperationType.Uninstall
                        : OperationType.Install,
                    ParentFloc = maintenanceWorkOrderOperationXmlDto.ParentFloc,
                    Emr = new EmrDto
                    {
                        Cage = maintenanceWorkOrderOperationXmlDto.Emr.Cage,
                        Mpn = maintenanceWorkOrderOperationXmlDto.Emr.Mpn,
                        Msn = maintenanceWorkOrderOperationXmlDto.Emr.Msn,
                    },
                    ParentEmr = parentEmr,
                    ParentExists = parentFlocDetails != null
                };
                operationsBizDto.Add(operation);
            }

            var bizDto = new MaintenanceWorkOrderDto(dto.Details.MWO_Number, dto.Details.MWO_Type,
                dto.Details.MWO_CloseDate, dto.Details.SB_Number, dto.Details.SB_Revision, operationsBizDto);

            var mwo = _service.RunBizAction<MaintenanceWorkOrder>(bizDto);

        }
    }
}

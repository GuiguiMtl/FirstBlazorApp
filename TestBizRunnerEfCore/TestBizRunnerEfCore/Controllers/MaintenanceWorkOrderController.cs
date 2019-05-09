using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BizLogic;
using DataLayer.Entities;
using GenericBizRunner;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Shared.Dtos;
using Shared.Enums;

namespace TestBizRunnerEfCore.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class MaintenanceWorkOrderController : Controller
    {
        //[HttpPost]
        //public IActionResult CreateMaintenanceWorkOrder(IFormFile uploadedFile,
        //    [FromServices] IActionService<ICreateMaintenanceWorkOrderAction> service)
        //{
        //    var xmlDocument = XDocument.Load(uploadedFile.OpenReadStream());
        //    var serializer = new XmlSerializer(typeof(MaintenanceWorkOrderXmlDto));
        //    var dto = (MaintenanceWorkOrderXmlDto) serializer.Deserialize(xmlDocument.CreateReader());

        //    var operationsBizDto = new List<OperationDto>();
        //    foreach (var maintenanceWorkOrderOperationXmlDto in dto.Operations)
        //    {
        //        EmrDto parentEmr = null;
        //        if (maintenanceWorkOrderOperationXmlDto.ParentEmr != null)
        //        {
        //            parentEmr = new EmrDto
        //            {
        //                Cage = maintenanceWorkOrderOperationXmlDto.ParentEmr.Cage,
        //                Mpn = maintenanceWorkOrderOperationXmlDto.ParentEmr.Mpn,
        //                Msn = maintenanceWorkOrderOperationXmlDto.ParentEmr.Msn,
        //            };
        //        }

        //        var operation = new OperationDto
        //        {
        //            OperationType = maintenanceWorkOrderOperationXmlDto.Type == "U"
        //                ? OperationType.Uninstall
        //                : OperationType.Install,
        //            ParentFloc = maintenanceWorkOrderOperationXmlDto.ParentFloc,
        //            Emr = new EmrDto
        //            {
        //                Cage = maintenanceWorkOrderOperationXmlDto.Emr.Cage,
        //                Mpn = maintenanceWorkOrderOperationXmlDto.Emr.Mpn,
        //                Msn = maintenanceWorkOrderOperationXmlDto.Emr.Msn,
        //            },
        //            ParentEmr = parentEmr
        //        };
        //        operationsBizDto.Add(operation);
        //    }

        //    var bizDto = new MaintenanceWorkOrderDto(dto.Details.MWO_Number, dto.Details.MWO_Type,
        //        dto.Details.MWO_CloseDate, dto.Details.SB_Number, dto.Details.SB_Revision, operationsBizDto);

        //    var mwo = service.RunBizAction<MaintenanceWorkOrder>(bizDto);

        //    return service.Status.ResponseWithValidCode(200).Result;
        //}


        [HttpPost]
        public IActionResult CreateMaintenanceWorkOrder(IFormFile uploadedFile,
            [FromServices] ICreateMaintenanceWorkOrderService service, IActionService<ICreateMaintenanceWorkOrderAction> service2)
        {
            var xmlDocument = XDocument.Load(uploadedFile.OpenReadStream());
            var serializer = new XmlSerializer(typeof(MaintenanceWorkOrderXmlDto));
            var dto = (MaintenanceWorkOrderXmlDto) serializer.Deserialize(xmlDocument.CreateReader());
            service.CreateMaintenanceWorkOrder(dto);
            return Ok();
        }
    }
}

//Finish Creating Context, Create config for file upload in swagger

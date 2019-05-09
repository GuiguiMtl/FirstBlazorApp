using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Shared.Dtos;

namespace BizLogic
{
    public class MaintenanceWorkOrderDto
    {

        public MaintenanceWorkOrderDto(string mwoNumber, string mwoType, DateTime mwoCloseDate, string sbNumber, string sbRevision, List<OperationDto> operations)
        {
            MWO_Number = mwoNumber;
            MWO_Type = mwoType;
            MWO_CloseDate = mwoCloseDate;
            SB_Number = sbNumber;
            SB_Revision = sbRevision;
            Operations = operations;
        }

        public string MWO_Number { get; }

        public string MWO_Type { get; }

        public DateTime MWO_CloseDate { get; }

        public string SB_Number { get;  }

        public string SB_Revision { get; }

        public List<OperationDto> Operations { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ServiceLayer
{
    [XmlRoot("MWO")]

    public class MaintenanceWorkOrderXmlDto
    {
        [XmlElement("Details")]
        public DetailsMaintenanceWorkOrder Details { get; set; }
        
        [XmlArray("Operations")]
        [XmlArrayItem("Operation")]
        public List<MaintenanceWorkOrderOperationXmlDto> Operations { get; set; }
    }

    public class DetailsMaintenanceWorkOrder
    {
        [XmlElement("MWO_Number")]
        public string MWO_Number { get; set; }

        [XmlElement("MWO_Type")]
        public string MWO_Type { get; set; }

        [XmlElement("MWO_CloseDate")]
        public DateTime MWO_CloseDate { get; set; }

        [XmlElement("SB_Number")]
        public string SB_Number { get; set; }

        [XmlElement("SB_Revision")]
        public string SB_Revision { get; set; }
    }

    public class MaintenanceWorkOrderOperationXmlDto
    {
        [XmlElement("Action")]
        public string Type { get; set; }

        [XmlElement("EMR")]
        public EmrXmlDto Emr { get; set; }

        [XmlElement("ParentEMR")]
        public EmrXmlDto ParentEmr { get; set; }

        [XmlElement("ParentFLOC")]
        public string ParentFloc { get; set; }

    }

    public class EmrXmlDto
    {
        [XmlElement("CAGE")]
        public string Cage { get; set; }

        [XmlElement("MPN")]
        public string Mpn { get; set; }

        [XmlElement("MSN")]
        public string Msn { get; set; }
    }
}

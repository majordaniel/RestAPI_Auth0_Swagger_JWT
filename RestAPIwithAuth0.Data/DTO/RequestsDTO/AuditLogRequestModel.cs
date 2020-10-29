using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.RequestsDTO
{
  public  class AuditLogRequestModel
    {

        public string UserId { get; set; }
        public DateTime EventDate { get; set; }
        public int EventType { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string ModifiedValue { get; set; }
        public string IPAddress { get; set; }
    }
}

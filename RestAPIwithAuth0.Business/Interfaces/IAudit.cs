using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Interfaces
{
   public interface IAudit
    {
        Task<bool> LogToAudit(Audit model);
    }
}

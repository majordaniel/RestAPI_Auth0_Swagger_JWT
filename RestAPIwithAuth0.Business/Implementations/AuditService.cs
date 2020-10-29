using Newtonsoft.Json.Linq;
using RestAPIwithAuth0.Business.Interfaces;
using RestAPIwithAuth0.Data.Configs;
using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Implementations
{
    public class AuditService : IAudit
    {

        ApplicationDbContext _dbContext;
        public AuditService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> LogToAudit(Audit model)
        {
            try
            {
                model = (await _dbContext.Audits.AddAsync(model)).Entity;
               var count = await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // todo: Log the error and return false;
                return false;
            }
        }
    }
}
